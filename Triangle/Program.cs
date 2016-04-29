using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static int count = 1;
        static void Main(string[] args)
        {
            //файл с данными первого треугольника;
            string puth1 = "simple_triangle.txt";
            //файл с данными второго треугольника;
            string puth2 = "triangle.txt";
            func(puth1);
            func(puth2);
            Console.ReadLine();
        }

        static void func(string puth)
        {
            //Заполнение из файла массива-условия задачи;
            StreamReader sr = null;
            int size = 0;
            int[][] myArr = null;
            try
            {
                sr = new StreamReader(puth, Encoding.UTF8);
                size = File.ReadLines(puth).Count();
                myArr = new int[size][];
                string line;
                int length = 0;
                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    string[] str = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    length = str.Length;
                    myArr[i] = new int[length];
                    for (int j = 0; j < length; j++)
                        myArr[i][j] = Convert.ToInt32(str[j]);
                }
                sr.Dispose();
                //Вывод массива - условия;
                /*for (int i = 0; i < size; i++)
                {
                    foreach (int x in myArr[i])
                        Console.Write(x + " ");
                    Console.WriteLine();
                }*/
                // Непосредственно решение;
                for (int i = size - 2; i >= 0; i--)
                {
                    for (int j = 0; j < myArr[i].Length; j++)
                    {
                        if (myArr[i + 1][j] > myArr[i + 1][j + 1])
                            myArr[i][j] += myArr[i + 1][j];
                        else
                            myArr[i][j] += myArr[i + 1][j + 1];
                    }
                }
                Console.WriteLine("Максимальная сумма пути от вершины до основания треугольника № " + count + ": " + myArr[0][0]);
            }
            catch
            {
                Console.WriteLine("Не найден файл по указанному пути!");
            }
            count++;
            Console.WriteLine();
        }
    }
}

