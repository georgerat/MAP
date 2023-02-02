using System;
using System.Drawing;
using System.Windows.Forms;

namespace P5
{
    //Se da o multime de n puncte in plan. Partitionati aceasta multime in 4 parti disjuncte, complementare a.i. suma distantelor
    //de la fiecare punct la centrul de greutate al partitiei din care face parte sa fie minima.

    public partial class Form1 : Form
    {
        const int NumarMultimi = 4;
        const int NumarPuncte = 40;
        Point[] puncte = new Point[NumarPuncte];
        Point[] multimi = new Point[NumarMultimi];

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            Pen pen1 = new Pen(new SolidBrush(Color.Blue));
            Pen pen2 = new Pen(new SolidBrush(Color.Red));
            Random random = new Random();

            //Generare puncte aleatoriu
            for (int i = 0; i < NumarPuncte; i++)
                puncte[i] = new Point { X = random.Next(0, panel1.Width), Y = random.Next(0, panel1.Height) };

            //Initializare centre multimi aleatoriu
            for (int i = 0; i < NumarMultimi; i++)
                multimi[i] = new Point { X = random.Next(0, panel1.Width), Y = random.Next(0, panel1.Height) };

            bool changed = true;
            while (changed)
            {
                changed = false;
                int[] MultimeNoua = new int[NumarPuncte];

                //Atasarea punctelor de multimi
                for (int i = 0; i < NumarPuncte; i++)
                {
                    int CeaMaiApropiataMultime = 0;
                    int DistantaMinima = int.MaxValue;

                    for (int j = 0; j < NumarMultimi; j++)
                    {
                        int distanta = (int)Math.Sqrt(Math.Pow(multimi[j].X - puncte[i].X, 2) +
                            Math.Pow(multimi[j].Y - puncte[i].Y, 2));
                        if (distanta < DistantaMinima)
                        {
                            CeaMaiApropiataMultime = j;
                            DistantaMinima = distanta;
                        }
                    }

                    MultimeNoua[i] = CeaMaiApropiataMultime;

                    if (MultimeNoua[i] != CeaMaiApropiataMultime)
                        changed = true;
                }

                //Recalculare centre multimi
                for (int i = 0; i < NumarMultimi; i++)
                {
                    int sumX = 0, sumY = 0;
                    int k = 0;

                    for (int j = 0; j < NumarPuncte; j++)
                        if (MultimeNoua[j] == i)
                        {
                            sumX += puncte[j].X;
                            sumY += puncte[j].Y;
                            k++;
                        }

                    if (k > 0)
                    {
                        multimi[i].X = sumX / k;
                        multimi[i].Y = sumY / k;
                    }
                }

                for (int i = 0; i < NumarMultimi; i++)
                    for (int j = 0; j < NumarPuncte; j++)
                        if (MultimeNoua[j] == i)
                            grp.DrawLine(pen1, multimi[i].X, multimi[i].Y, puncte[j].X, puncte[j].Y);
            }

            //Desenare puncte
            for (int i = 0; i < NumarPuncte; i++)
                grp.DrawEllipse(pen1, puncte[i].X, puncte[i].Y, 3, 3);

            //Desenare centre multimi
            for (int i = 0; i < NumarMultimi; i++)
                grp.DrawEllipse(pen2, multimi[i].X, multimi[i].Y, 5, 5);
        }
    }
}
