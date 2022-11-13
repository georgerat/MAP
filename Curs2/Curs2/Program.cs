using System;

namespace Curs2
{
    class Program
    {
        static int nr = 0;

        static void H(int n, char A, char B, char C)
        {
            if (n == 1)
            {
                Console.WriteLine(A + "->" + C);
                nr++;
            }
            else
            {
                H(n - 1, A, C, B);
                H(1, A, B, C);
                H(n - 1, B, A, C);
            }
        }

        static void H2(int n, char A, char B, char C, char D)
        {
            if (n == 1)
            {
                Console.WriteLine(A + "->" + D);
                nr++;
            }
            else if (n == 2)
            {
                H2(1, A, B, D, C);
                H2(1, A, B, C, D);
                H2(1, C, A, B, D);
            }
            else
            {
                H2(n - 2, A, C, D, B);
                H2(1, A, B, D, C);
                H2(1, A, B, C, D);
                H2(1, C, A, B, D);
                H2(n - 2, B, A, C, D);
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //H(n, 'A', 'B', 'C');
            H2(n, 'A', 'B', 'C', 'D');
            Console.WriteLine(nr);
            Console.ReadKey();
        }
    }
}
