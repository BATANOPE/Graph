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
        private List<List<int>> matr = new List<List<int>>();
        private int size;

        public int getSize
        {
            get { return size; }
        }

        //номера вершин
        private List<int> levels = new List<int>();

        private int numberOfLevels;


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
                    //MessageBox.Show(split[j]);
                    //конвертируем строку в int
                    stringMath.Add(Convert.ToInt32(split[j]));
                }

                //добавить строку в матрицу смежности
                matr.Add(stringMath);
            }

            //закрытие потока чтения
            sr.Close();

        }


        public Bitmap drawGraph(Bitmap bmp, PictureBox picture)
        {
            Graphics drawGr = Graphics.FromImage(bmp);

            int x = picture.Width / 2;
            int y = picture.Height / 2;

            int buf = 0;
            int size1 = size;
            int size2 = size;
            if (size >= 50)
                size2 = 50;
            

            PointF[] cord = new PointF[size];

            for (int i = 0; i < size; i++)
            {

                if (i % 50 == 0 && i != 0)
                {
                    buf += 35;
                    size1 -= 50;
                }

                if (size1 > 50)
                    size2 = 50;
                else
                    if (size1 > 0)
                    size2 = size1;

                cord[i].X = (float)(x + (Math.Cos((Math.PI / 2) + (2 * Math.PI / size2) * (i % 50)) * (-360 + buf)));
                cord[i].Y = (float)(y + (Math.Sin((Math.PI / 2) + (2 * Math.PI / size2) * (i % 50)) * (-360 + buf)));
            }

            for (int i = 0; i < size; i++)
            {

                drawGr.DrawString(Convert.ToString(i + 1), new Font("Arial", 10), Brushes.Red, cord[i].X - 7, cord[i].Y - 20);
                drawGr.FillEllipse(Brushes.Green, new Rectangle((int)(cord[i].X - 6), (int)(cord[i].Y - 6), 13, 13));

                for (int j = 0; j < size; j++)
                {

                    if (matr[i][j] != 0)
                    {
                        drawGr.DrawLine(new Pen(Color.Black), cord[i], cord[j]);
                    }
                }
            }
                       
            return bmp;
        }


        public Bitmap drawTree(Bitmap bmp, PictureBox picture)
        {
            Graphics drawTree = Graphics.FromImage(bmp);

            int x = picture.Width;
            int y = picture.Height;



            PointF[] cord = new PointF[size];

            for (int i = 1; i <= numberOfLevels; i++)
            {

                int k = 1;

               // MessageBox.Show(Convert.ToString(VertexOfLevel(i)), Convert.ToString(i + 1));

                for (int j = 0; j < size; j++)
                {
                    if (levels[j] == i)
                    {
                        cord[j].X = (float)( k * x / (VertexOfLevel(i) + 1) - 200);
                        cord[j].Y = (float)( i * (y / numberOfLevels) - 100);

                        k++;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {

                drawTree.DrawString(Convert.ToString(i + 1), new Font("Arial", 10), Brushes.Red, cord[i].X - 7, cord[i].Y - 20);
                drawTree.FillEllipse(Brushes.Green, new Rectangle((int)(cord[i].X - 6), (int)(cord[i].Y - 6), 13, 13));

                for (int j = 0; j < size; j++)
                {

                    if (matr[i][j] != 0)
                    {
                        drawTree.DrawLine(new Pen(Color.Black), cord[i], cord[j]);
                    }
                }
            }

            return bmp;
        }


        
        public void AddVer()
        {
            matr.Add(new List<int>());

            for (int i = 0; i < size; i++)
            {
                matr[i].Add(0);
                matr[size].Add(0);
            }
            matr[size].Add(0);

            size++;

            return;
        }


        public void DelVer(int number)
        {
            
            if (number > size || size == 0) return;
            if (number == -1)
                number = size;

            matr.RemoveAt(number - 1);

            size--;

            for (int i = 0; i < size; i++)
                matr[i].RemoveAt(number - 1);

            return;
        }


        public void DelEdge(int num1, int num2)
        {
            if (num1 > size || num2 > size || size == 0) return;

            matr[num1 - 1][num2 - 1] = 0;
            matr[num2 - 1][num1 - 1] = 0;

            return;
        }


        public void AddEdge(int start, int finish)
        {
            if (start > size || finish > size || size == 0) return;

            matr[start - 1][finish - 1] = 1;
            matr[finish - 1][start - 1] = 1;
        }

        //проставление вершинам уровней
        public void Level()
        {

            int lvlC = levels.Count;

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
            
            for (int i = 0; i < size; i++)
                levels[i] = 0;

           

           for (int i = 0; i < size; i++)
           {
                if (levels[i] == 0)
                    levels[i] = 1;

                 //MessageBox.Show(Convert.ToString(levels[i]), Convert.ToString(i + 1));

                giveNumber(1, i);
               
           }

           int k = 1;
           for (int i = 0; i < size; i++)
           {
                k = Math.Max(k, levels[i]);
               // MessageBox.Show(Convert.ToString(levels[i]), "вершина ЙКУЙ " + Convert.ToString(i + 1));
           }

           //количество уровней
            numberOfLevels = k;
            //MessageBox.Show(Convert.ToString(numberOfLevels), "количество уровней");
            return;
        }


        //рекурсия по всем вершинам
        private void giveNumber(int number, int ver)
        {
            for (int j = 0; j < size; j++)
            {
               if (matr[ver][j] != 0)
               {
                    if (levels[j] == 0)
                    {
                        levels[j] = number + 1;
                        //MessageBox.Show(Convert.ToString(levels[j]), "вершина рекурсия" + Convert.ToString(j + 1));
                        giveNumber(number + 1, j);
                    }
                    else
                    {
                        if (levels[ver] > levels[j] + 1)
                            levels[ver] = levels[j] + 1;
                    }
                }
                
                
                //MessageBox.Show(Convert.ToString(levels[j]), "вершина ЙКУЙ " + Convert.ToString(j + 1));
            }
        }

        //количество вершин переданного уровня
        public int VertexOfLevel(int number)
        {

            int count = 0;

            for (int i = 0; i < size; i++)
            {
                //MessageBox.Show(Convert.ToString(levels[i]), "Номер вершины " + Convert.ToString(i + 1));
                if (levels[i] == number)
                    count++;
            }

            return count;

        }


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
