using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Graph
{
    public partial class Form1 : Form
    {
        //объявление объекта графа
        Graph gr;

        //путь к файлу
        string way;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }           //случайно тыкнул

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }           //случайно тыкнул


        //открытие файла
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //открытие файла
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //если открывают txt файл
                if (openFileDialog1.FileName.Contains(".txt") == true)
                {
                    way = openFileDialog1.FileName;
                }
                else
                    MessageBox.Show("Вы выбрали не текстовый файл", "Error");
            }

            //передаем путь к файлу в конструктор, там заполняется матрица смежности
            if (way != null)
                gr = new Graph(way);
            
        }

        //сохранить в файл
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //если есть что сохранять
            if (gr != null)
            {
                              
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                //если открыт файл для записи
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName.Contains(".txt") == true)
                    {
                        //путь запоминается и передается для сохранения
                        way = saveFileDialog1.FileName;
                        gr.Save(way);
                    }
                    else
                        MessageBox.Show("Вы выбрали не текстовый файл", "Error");
                  
                }
            }
            else
                MessageBox.Show("А сохранять-то нечего","Error");
        }

        //нарисовать
        private void btDraw_Click(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);
                             
            if (gr == null)
            {
                MessageBox.Show("Нечего рисовать", "Error");
                return;
            }

            //рисуем в битмапе и выводим на экран
            bmp = gr.drawGraph(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;

        }

        //добавить вершину
        private void btAdd_Click(object sender, EventArgs e)
        {

            //если ничего не было, то создаем ноый граф
            if (gr == null)
                gr = new Graph();

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);

            //добавление вершины
            gr.AddVer();

            //рисуем в битмапе и выводим на экран
            bmp = gr.drawGraph(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;

        }

        //удалить вершину
        private void btDelVer_Click(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);

            //номер вершины, если не задана вручную -1
            int number = -1;

            //если вершина введена, запоминаем
            if (txtbDelVer.Text != "")
            {
                number = Convert.ToInt32(txtbDelVer.Text);
                txtbDelVer.Text = "";
            }
                       
            //удаление
            gr.DelVer(number);

            bmp = gr.drawGraph(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;
        }

        //Сделать операцию с ребрами
        private void btEdge_Click(object sender, EventArgs e)
        {
            //если есть граф
            if (gr != null)
            {
                Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);

                //если введены обе вершины
                if (txtbStart.Text != "" && txtbFinish.Text != "")
                {

                    //номера вершин запоминаются
                    int start = Convert.ToInt32(txtbStart.Text);
                    int finish = Convert.ToInt32(txtbFinish.Text);

                    //если выбрано удаление
                    if (radBtDel.Checked)
                    {
                        //удалить вершину
                        gr.DelEdge(start, finish);
                        bmp = gr.drawGraph(bmp, pctrBxGraph);
                         pctrBxGraph.Image = bmp;
                    }
                    //если выбрано добавление
                    if (radBtAdd.Checked)
                    {
                        //добавить вершину
                        gr.AddEdge(start, finish);
                        bmp = gr.drawGraph(bmp, pctrBxGraph);
                        pctrBxGraph.Image = bmp;  
                    }
                    else
                        return;

                    pctrBxGraph.Image = bmp;
                }
                else
                    MessageBox.Show("Вы не указали номер(а) вершин(ы)", "Error");
            }
        }

        //нарисовать дерево
        private void btDrawTree_Click(object sender, EventArgs e)
        {

            if (gr == null)
            {
                MessageBox.Show("Нечего рисовать", "Error");
                return;
            }

            //пронумерование уровнями всех вершин
            gr.Level();

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);
                        
            //нарисовать дерево
            bmp = gr.drawTree(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;

        }


        //обработка кейпрессов
        private void txtbDelVer_KeyPress(object sender, KeyPressEventArgs e)
        {

            //если введено число, то не жалуемся
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            else
            {
                //разрешение удаления
                if (e.KeyChar == '\b')
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtbStart_KeyPress(object sender, KeyPressEventArgs e)
        {

            //если введено число, то не жалуемся
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            else
            {
                //разрешение удаления
                if (e.KeyChar == '\b')
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtbFinish_KeyPress(object sender, KeyPressEventArgs e)
        {

            //если введено число, то не жалуемся
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            else
            {
                //разрешение удаления
                if (e.KeyChar == '\b')
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
