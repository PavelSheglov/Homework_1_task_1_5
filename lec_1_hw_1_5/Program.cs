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
            int N = InputSize();
            int[,] matrix1 = GenerateArray(N,-2000, 2000), matrix2 = GenerateArray(N, -3000, 3000);
            int[,] sum = SumMatrix(matrix1, matrix2);

            Console.WriteLine("Первая матрица:");
            ShowMatrix(matrix1, GetOutputFormat(matrix1));
            Console.WriteLine("Вторая матрица:");
            ShowMatrix(matrix2, GetOutputFormat(matrix2));
            Console.WriteLine("Сумма матриц:");
            ShowMatrix(sum, GetOutputFormat(sum));
        }

        static int InputSize()
        {
            int N = 0;
            const int maxsize = 10;
            Console.Clear();
            do
            {
                 try
                 {
                      Console.Write($"Введите размерность N (max {maxsize}) для 2-х квадратных матриц:");
                      N = Convert.ToInt32(Console.ReadLine());
                 }
                 catch (FormatException)
                {
                     Console.WriteLine("Ошибка при вводе числа!!!!");
                }
             } while (N <= 0 || N > maxsize);
             return N;
         }

        static int[,] GenerateArray(int size, int leftBorder, int rightBorder)
        {
            int[,] matrix = new int[size, size];
            Random rnd1 = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rnd1.Next(leftBorder, rightBorder);
            return matrix;     
        }

        static string GetOutputFormat(int [,] matrix)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int width = 0;
            foreach (int temp in matrix)
            {
                if (temp > max) max = temp;
                if (temp < min) min = temp;
            }
            width = (max.ToString().Length > min.ToString().Length ? max.ToString().Length : min.ToString().Length) + 2;
            return "{0," + width.ToString() + ":#}";
        }

        static void ShowMatrix(int[,] matrix, string format)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(format, matrix[i, j]);
                Console.WriteLine();
            }
        }

        static int[,] SumMatrix(int[,] matrix1, int[,] matrix2)
        {
            int[,] sum = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < sum.GetLength(0); i++)
                for (int j = 0; j < sum.GetLength(1); j++)
                    sum[i, j] = matrix1[i, j] + matrix2[i, j];
            return sum;
        }
    }
}

