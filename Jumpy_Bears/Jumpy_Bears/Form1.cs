using System;
using System.Windows.Forms;

namespace Jumpy_Bears
{
    public partial class Form1 : Form
    {
        public Player player;
        bool start = false;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Move();
            Engine.CheckIfYouLose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Engine.Initialize(this);
            player = new Player();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.isMovingLeft = true;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                player.isMovingRight = true;
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (!player.isJumping)
                    player.gravity = -Player.maxGravity;
                player.isJumping = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (start == false)
                {
                    timer1.Enabled = true;
                    start = true;
                    label1.Visible = false;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.isMovingLeft = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                player.isMovingRight = false;
        }
    }
}
