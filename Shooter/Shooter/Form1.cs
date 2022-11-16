using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form1 : Form
    {
        public Image background = Image.FromFile("../../images/Fundal.jpg");
        public Image gun1 = Image.FromFile("../../images/Gun1.png");
        public SoundPlayer backgroundSound = new SoundPlayer("../../sounds/Thriller.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Engine.BlurBackground();

                timer1.Enabled = false;
                var option = MessageBox.Show("Are you sure?", "Exit Game", MessageBoxButtons.OKCancel);
                if (option == DialogResult.OK)
                {
                    Close();
                }
                timer1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = MenuScreen.Width = Width;
            pictureBox1.Height = MenuScreen.Height = Height;

            TimeLabel.Parent = WaveLabel.Parent = HealthLabel.Parent = pictureBox1;
            gun.Parent = pictureBox1;

            startButton.Parent = exitButton.Parent = MenuScreen;
            startButton.Left = exitButton.Left = this.Width / 2 - startButton.Width / 2;
            startButton.Top = this.Height / 2 - startButton.Height;
            exitButton.Top = this.Height / 2;

            Engine.Init(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Tick();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Shoot(e.Location);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            gun.Location = new Point(e.Location.X, e.Location.Y + 20);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            MenuScreen.Enabled = false;
            MenuScreen.Visible = false;
            backgroundSound.PlayLooping();
        }
    }
}
