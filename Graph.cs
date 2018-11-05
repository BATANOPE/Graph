using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Graph
{
    class Graph
    {
        //объявление матрицы смежности и ее размерa
        private List<List<int>> matr = new List<List<int>>();
        private int size;

        public int getSize
        {
            get { return size; }
        }

        //уровень каждой вершины
        private List<int> levels = new List<int>();

        //количество уровней
        private int numberOfLevels;


        //конструктор, все изначально 0
        public Graph()
        {
            size = 0;

            matr.Add(new List<int>());
            matr[0].Add(0);
        }

        //конструктор заполнения матрицы смежности, где n - размер, split - разделенная строка
        public Graph(string way)
        {

            StreamReader sr = new StreamReader(way);

            //считываем первую строку - число вершин графа
            string curstr = sr.ReadLine();
            size = Convert.ToInt32(curstr);

            
            for (int i = 0; i < size; i++)
            {

                //считываем каждую строку и делим ее сплитом
                curstr = sr.ReadLine();
                string[] split = curstr.Split(' ');

                //выделение места под каждую строку
                List<int> stringMath = new List<int>();
                
                for (int j = 0; j < size; j++)
                {
                    //конвертируем строку в int
                    stringMath.Add(Convert.ToInt32(split[j]));
                }

                //добавить строку в матрицу смежности
                matr.Add(stringMath);
            }

            //закрытие потока чтения
            sr.Close();

        }

        
        //рисование графа
        public Bitmap drawGraph(Bitmap bmp, PictureBox picture)
        {

            Graphics drawGr = Graphics.FromImage(bmp);

            //для удобства
            int x = picture.Width / 2;
            int y = picture.Height / 2;

            //требуется для уменьшения каждого нового круга
            int buf = 0;

            //количество не нарисованных вершин
            int size1 = size;

            //для рисования точек по кругу
            int size2 = size;

            //если вершин >50, то ограничиваем, чтобы в каждом кругу было их не более 50
            if (size >= 50)
                size2 = 50;
            
            //массив координат
            PointF[] cord = new PointF[size];

            //заполнение координат каждой точки
            for (int i = 0; i < size; i++)
            {

                //если превышаем отметку в кратное 50-ти число вершин, делаем меньший круг
                if (i % 50 == 0 && i != 0)
                {
                    //уменьшаем радиус нового круга и количество не нарисованных вершин
                    buf += 35;
                    size1 -= 50;
                }

                //если вершин >50, то ограничиваем, чтобы в каждом кругу было их не более 50
                if (size1 > 50)
                    size2 = 50;
                else
                    if (size1 > 0)
                    size2 = size1;

                //заполнение координат для конкретного пикчербокса
                cord[i].X = (float)(x + (Math.Cos((Math.PI / 2) + (2 * Math.PI / size2) * (i % 50)) * (-360 + buf)));
                cord[i].Y = (float)(y + (Math.Sin((Math.PI / 2) + (2 * Math.PI / size2) * (i % 50)) * (-360 + buf)));
            }

            //рисование
            for (int i = 0; i < size; i++)
            {
                //рисуем номера вершин и сами вершины
                drawGr.DrawString(Convert.ToString(i + 1), new Font("Arial", 10), Brushes.Red, cord[i].X - 7, cord[i].Y - 20);
                drawGr.FillEllipse(Brushes.Green, new Rectangle((int)(cord[i].X - 6), (int)(cord[i].Y - 6), 13, 13));

                for (int j = 0; j < size; j++)
                {

                    //если есть ребро между вершинами, рисуем его
                    if (matr[i][j] != 0)
                    {
                        drawGr.DrawLine(new Pen(Color.Black), cord[i], cord[j]);
                    }
                }
            }
                       
            return bmp;
        }


        //рисование дерева
        public Bitmap drawTree(Bitmap bmp, PictureBox picture)
        {
            Graphics drawTree = Graphics.FromImage(bmp);

            //для удобства
            int x = picture.Width;
            int y = picture.Height;


            
            PointF[] cord = new PointF[size];

            //заполнение координат для каждого уровня
            for (int i = 1; i <= numberOfLevels; i++)
            {

                //порядок вершины среди всех на ее уровне
                int n = 1;

                //заполнение координат
                for (int j = 0; j < size; j++)
                {
                    //если уровень вершины совпадает с тем, который рисуем
                    if (levels[j] == i)
                    {
                        //равномерно распределяем по пикчербоксу
                        cord[j].X = (float)( n * x / (VertexOfLevel(i) + 1));
                        cord[j].Y = (float)( i * (y / numberOfLevels) - 15);

                        n++;
                    }
                }
            }

            //рисование
            for (int i = 0; i < size; i++)
            {

                drawTree.DrawString(Convert.ToString(i + 1), new Font("Arial", 10), Brushes.Red, cord[i].X - 7, cord[i].Y - 20);
                drawTree.FillEllipse(Brushes.Green, new Rectangle((int)(cord[i].X - 6), (int)(cord[i].Y - 6), 13, 13));

                for (int j = 0; j < size; j++)
                {

                    //если есть ребро между вершинами
                    if (matr[i][j] != 0)
                    {
                        drawTree.DrawLine(new Pen(Color.Black), cord[i], cord[j]);
                    }
                }
            }

            return bmp;
        }


        //добавить вершину
        public void AddVer()
        {
            //выделяем место под строку
            matr.Add(new List<int>());

            //заполняем новую строку и столбец нулями
            for (int i = 0; i < size; i++)
            {
                matr[i].Add(0);
                matr[size].Add(0);
            }
            matr[size].Add(0);

            size++;

            return;
        }


        //удалить вершину
        public void DelVer(int number)
        {
            
            if (number > size || size == 0) return;
            if (number == -1)
                number = size;

            //удаление столбца и строки из матрицы смежности

            matr.RemoveAt(number - 1);

            size--;

            for (int i = 0; i < size; i++)
                matr[i].RemoveAt(number - 1);

            return;
        }


        //удалить ербро
        public void DelEdge(int num1, int num2)
        {

            if (num1 > size || num2 > size || size == 0) return;

            matr[num1 - 1][num2 - 1] = 0;
            matr[num2 - 1][num1 - 1] = 0;

            return;
        }


        //добавить ребро
        public void AddEdge(int start, int finish)
        {
            if (start > size || finish > size || size == 0) return;

            matr[start - 1][finish - 1] = 1;
            matr[finish - 1][start - 1] = 1;
        }

        //проставление вершинам уровней
        public void Level()
        {

            //колчиество вершин с уровнями
            int lvlC = levels.Count;

            //если вершин больше
            if (lvlC < size)
            {
               
                for (int i = 0; i < size - lvlC; i++)
                {
                    levels.Add(0);
                   
                }
            }
            else
            {
                if (lvlC > size)
                {
                    for (int i = 0; i < lvlC - size; i++)
                        levels.RemoveAt(1);
                }
            }
            
            //всем проставляем уровень 0
            for (int i = 0; i < size; i++)
                levels[i] = 0;

           

           for (int i = 0; i < size; i++)
           {
                //если не проставлен уровень, то ставим первый
                if (levels[i] == 0)
                    levels[i] = 1;

                //рекурсия по вершинам начиная с нашей, у которой 1 уровень
                giveNumber(1, i);
               
           }

           //подсчет количества уровней
           int k = 1;
           for (int i = 0; i < size; i++)
           {
                
                k = Math.Max(k, levels[i]);
               
           }

           //количество уровней
            numberOfLevels = k;
            
            return;
        }


        //рекурсия по всем вершинам
        private void giveNumber(int number, int ver)
        {
            for (int j = 0; j < size; j++)
            {
                //если есть ребро
               if (matr[ver][j] != 0)
               {
                    //если не проставлен уровень
                    if (levels[j] == 0)
                    {
                        //уровень на 1 больше, чем у предыдущего и запускаем рекурсию от этой вершины
                        levels[j] = number + 1;
                        giveNumber(number + 1, j);
                    }
                    else
                    {
                        //если у вершины, из которой пришли, уровень больше текущего, то меняем уровень предшественника
                        if (levels[ver] > levels[j] + 1)
                            levels[ver] = levels[j] + 1;
                    }
                }
                
                
               
            }
        }


        //количество вершин переданного уровня
        public int VertexOfLevel(int number)
        {

            int count = 0;

            for (int i = 0; i < size; i++)
            {
                
                if (levels[i] == number)
                    count++;
            }

            return count;

        }


        //сохранение в файл
        public void Save(string way)
        {

            StreamWriter save = new StreamWriter(way);
            save.WriteLine(size.ToString());

            for (int i = 0; i < size; i++)
            {

                string str = "";

                for (int j = 0; j < size; j++)
                {
                    str += matr[i][j] + " ";
                }
                save.WriteLine(str);
            }
            save.Close();
            return;
        }
    }
}
