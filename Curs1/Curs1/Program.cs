using System;
using System.IO;

namespace Curs1
{
    class Program
    {
        static void Main()
        {
            TextReader load = new StreamReader(@"../../TextFile1.txt");
            int n = int.Parse(load.ReadLine());

            int[,] a = new int[n, n];
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] t = buffer.Split(' ');
                int NS = int.Parse(t[0]);
                int NE = int.Parse(t[1]);
                a[NS, NE] = 1;
                a[NE, NS] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            int nrimpare = 0;

            for (int i = 0; i < n; i++)
            {
                int s = 0;
                for (int j = 0; j < n; j++)
                    if (a[i, j] == 1)
                        s++;
                if (s % 2 == 1)
                    nrimpare++;
            }

            if (nrimpare > 2)
                Console.WriteLine("Graful nu este eulerian.");
            else
                Console.WriteLine("Graful este eulerian.");
            Console.WriteLine();
        }
    }
}
