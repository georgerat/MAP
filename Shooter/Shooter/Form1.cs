using System;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            Engine.Init(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Enemy enemy in Engine.enemies)
            {
                enemy.Move();
                Engine.UpdateDisplay();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Shoot(e.Location);
        }
    }
}
