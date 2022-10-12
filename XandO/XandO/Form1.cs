using System;
using System.Drawing;
using System.Windows.Forms;

namespace XandO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 3;
        Button[,] buttons;
        int player = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttons == null)
            {
                buttons = new Button[n, n];
                int size = pictureBox1.Width / 3;

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        Button button = new Button();
                        button.Size = new Size(size, size);
                        button.Parent = pictureBox1;
                        button.Location = new Point(j * size, i * size);
                        button.Font = new Font("Arial", 30);
                        button.Click += gridButton_Click;
                        buttons[i, j] = button;
                    }
            }
            else
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i, j].Enabled = true;
                        buttons[i, j].Text = "";
                    }
            }
        }

        private void gridButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (player == 1)
            {
                button.Text = "X";
                player = 2;
                button.Enabled = false;
            }
            else
            {
                button.Text = "O";
                player = 1;
                button.Enabled = false;
            }

            if (CheckGameWon())
            {
                if (player == 1)
                    MessageBox.Show("Player 2 a castigat.");
                else if (player == 2)
                    MessageBox.Show("Player 1 a castigat.");
            }
            else if (CheckGameLost())
                MessageBox.Show("Remiza");
        }

        bool CheckGameLost()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (buttons[i, j].Enabled)
                        return false;
            return true;
        }

        bool CheckGameWon()
        {
            int sx, sy;
            for (int i = 0; i < n; i++)
            {
                sx = 0;
                sy = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Text == "X")
                        sx++;
                    if (buttons[i, j].Text == "O")
                        sy++;
                }
                if (sx == 3 || sy == 3)
                    return true;

                sx = 0;
                sy = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[j, i].Text == "X")
                        sx++;
                    if (buttons[j, i].Text == "O")
                        sy++;
                }
                if (sx == 3 || sy == 3)
                    return true;
            }

            sx = 0;
            sy = 0;
            for (int i = 0; i < n; i++)
            {
                if (buttons[i, i].Text == "X")
                    sx++;
                else if (buttons[i, i].Text == "O")
                    sy++;
            }
            if (sx == 3 || sy == 3)
                return true;

            sx = 0;
            sy = 0;
            for (int i = 0; i < n; i++)
            {
                if (buttons[i, n - i - 1].Text == "X")
                    sx++;
                else if (buttons[i, n - i - 1].Text == "O")
                    sy++;
            }
            if (sx == 3 || sy == 3)
                return true;

            return false;
        }
    }
}
