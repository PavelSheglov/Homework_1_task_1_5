using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lec_1_hw_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {//-------------------------------------------формирование матриц-----------------------------------------------------------------
                int N;
                const int maxsize = 10;
                do
                {
                    Console.Write($"Введите размерность N (max {maxsize}) для 2-х квадратных матриц:");
                    N = Convert.ToInt32(Console.ReadLine());
                } while (N <= 0 || N > maxsize);
                int[,] matrix1 = new int[N, N], matrix2 = new int[N, N];
                Random rnd1 = new Random();
                Random rnd2 = new Random();
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                    {
                        matrix1[i, j] = rnd1.Next(-2000, 2000);
                        matrix2[i, j] = rnd2.Next(-3000, 3000);
                    }
                //-----------------------------форматирование вывода 1-й матрицы-----------------------------------------------------------------
                int max1 = int.MinValue, max2 = int.MinValue;
                int min1 = int.MaxValue, min2 = int.MaxValue;
                foreach (int temp in matrix1)
                {
                    if (temp > max1) max1 = temp;
                    if (temp < min1) min1 = temp;
                }
                int width1 = (max1.ToString().Length > min1.ToString().Length ? max1.ToString().Length : min1.ToString().Length) + 2;
                string format1 = "{0," + width1.ToString() + ":#}";
                //-----------------------------форматирование вывода 2-й матрицы-----------------------------------------------------------------
                foreach (int temp in matrix2)
                {
                    if (temp > max2) max2 = temp;
                    if (temp < min2) min2 = temp;
                }
                foreach (int temp in matrix2)
                {
                    if (temp > max2) max2 = temp;
                    if (temp < min1) min2 = temp;
                }
                int width2 = (max2.ToString().Length > min2.ToString().Length ? max2.ToString().Length : min2.ToString().Length) + 2;
                string format2 = "{0," + width2.ToString() + ":#}";
                //----------------------------------вывод обеих матрицы-----------------------------------------------------------------
                Console.WriteLine("Первая матрица:");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(format1, matrix1[i, j]);
                    Console.WriteLine();
                }
                Console.WriteLine("Вторая матрица:");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(format2, matrix2[i, j]);
                    Console.WriteLine();
                }
                //------------------------------суммирование 2-х матриц-----------------------------------------------------------------
                int[,] sum = new int[N, N];
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        sum[i, j] = matrix1[i, j] + matrix2[i, j];
                //-----------------------------форматирование вывода результирующей матрицы---------------------------------------------
                int maxres = int.MinValue, minres = int.MaxValue;
                foreach (int temp in matrix1)
                {
                    if (temp > maxres) maxres = temp;
                    if (temp < minres) minres = temp;
                }
                int widthres = (maxres.ToString().Length > minres.ToString().Length ? maxres.ToString().Length : minres.ToString().Length) + 2;
                string formatres = "{0," + widthres.ToString() + ":#}";
                //-----------------------------вывод результирующей матрицы-------------------------------------------------------------
                Console.WriteLine("Сумма матриц:");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(formatres, sum[i, j]);
                    Console.WriteLine();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Ошибка при вводе числа!!!!");
            }
        }
    }
}
