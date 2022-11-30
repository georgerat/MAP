using System;
using System.Windows.Forms;

namespace Jumpy_Bears
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control x in Controls)
            {
                if ((string)x.Tag == "platform")
                {
                    if (x.Top <= Height)
                        x.Top = x.Top + 5;
                    else
                    {
                        Random random = new Random();
                        int platformWidth = random.Next(100, 200);
                        int xa = random.Next(-20, 580 - platformWidth);
                        int ya = random.Next(50, 80);
                        x.Top = -ya;
                        x.Left = xa;
                        x.Height = 30;
                        x.Width = platformWidth;
                    }
                }
            }
        }
    }
}
