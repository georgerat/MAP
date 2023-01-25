using System;
using System.IO;
using System.Collections.Generic;

namespace Curs12
{
    public class Program
    {
        static int n, m;
        static int[,] matrix;

        static void Main()
        {
            ReadMatrix();
            ViewMatrix(matrix);
            for (int i = 0; i < 10; i++)
            {
                Tick();
                ViewMatrix(matrix);
            }
        }

        public static int[,] ReadMatrix()
        {
            TextReader load = new StreamReader(@"../../TextFile1.txt");
            List<string> T = new List<string>();
            string buffer;
            while ((buffer = load.ReadLine()) != null)
                T.Add(buffer);
            load.Close();
            n = T.Count;
            m = T[0].Split(' ').Length;
            matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] data = T[i].Split(' ');
                for (int j = 0; j < m; j++)
                    matrix[i, j] = int.Parse(data[j]);
            }
            return matrix;
        }

        public static void ViewMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Tick()
        {
            int[,] M = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int s = 0;
                    if (i - 1 >= 0) if (matrix[i - 1, j] == 1) s++;
                    if (i - 1 >= 0 && j + 1 < m) if (matrix[i - 1, j + 1] == 1) s++;
                    if (j + 1 < m) if (matrix[i, j + 1] == 1) s++;
                    if (i + 1 < n && j + 1 < m) if (matrix[i + 1, j + 1] == 1) s++;
                    if (i + 1 < n) if (matrix[i + 1, j] == 1) s++;
                    if (i + 1 < n && j - 1 >= 0) if (matrix[i + 1, j - 1] == 1) s++;
                    if (j - 1 >= 0) if (matrix[i, j - 1] == 1) s++;
                    if (i - 1 >= 0 && j - 1 >= 0) if (matrix[i - 1, j - 1] == 1) s++;

                    if (s % 2 == 0) M[i, j] = 0;
                    else M[i, j] = 1;
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = M[i, j];
        }
    }
}
