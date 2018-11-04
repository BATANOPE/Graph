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

            if (gr != null)
            {
                string way;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName.Contains(".txt") == true)
                    {
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

            bmp = gr.drawGraph(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;

        }

        //добавить вершину
        private void btAdd_Click(object sender, EventArgs e)
        {

            if (gr == null)
                gr = new Graph();

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);

            gr.AddVer();

            bmp = gr.drawGraph(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;

        }

        //удалить вершину
        private void btDelVer_Click(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);

            int number = -1;
            if (txtbDelVer.Text != "")
            {
                number = Convert.ToInt32(txtbDelVer.Text);
                txtbDelVer.Text = "";
            }
                       
            gr.DelVer(number);

            bmp = gr.drawGraph(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;
        }

        //Сделать операцию с ребрами
        private void btEdge_Click(object sender, EventArgs e)
        {
            if (gr != null)
            {
                Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);

                if (txtbStart.Text != "" && txtbFinish.Text != "")
                {

                    int start = Convert.ToInt32(txtbStart.Text);
                    int finish = Convert.ToInt32(txtbFinish.Text);

                    if (radBtDel.Checked)
                    {
                        gr.DelEdge(start, finish);
                        bmp = gr.drawGraph(bmp, pctrBxGraph);
                         pctrBxGraph.Image = bmp;
                    }
                    if (radBtAdd.Checked)
                    {
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

        private void btDrawTree_Click(object sender, EventArgs e)
        {

            if (gr == null)
            {
                MessageBox.Show("Нечего рисовать", "Error");
                return;
            }

            gr.Level();

            Bitmap bmp = new Bitmap(pctrBxGraph.Width, pctrBxGraph.Height);
                        

            bmp = gr.drawTree(bmp, pctrBxGraph);
            pctrBxGraph.Image = bmp;

        }


        //обработка кейпрессов
        private void txtbDelVer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            else
            {
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
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            else
            {
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
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            else
            {
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
