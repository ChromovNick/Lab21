using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        static int[,] garden;
        static int m;
        static int n;

        static void Main()
        {
            Console.WriteLine("Введите размерность сада (двумерного массива)");
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());

            garden = new int[n, m];

            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int delay = 1;
                    if (garden[i, j] >= 0)
                        garden[i, j] = -1;
                    Thread.Sleep(delay);
                }
            }
        }

        private static void Gardner2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    int delay = 3;
                    if (garden[j, i] >= 0)
                        garden[j, i] = -2;
                    Thread.Sleep(delay);
                }
            }
        }
    }
}
