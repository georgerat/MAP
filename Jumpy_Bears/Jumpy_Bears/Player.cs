using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jumpy_Bears
{
    public class Player
    {
        public PictureBox image;
        public int speed = 15, gravity, platformGravity = 5;
        public bool isMovingLeft, isMovingRight, isJumping = true;
        public const int maxGravity = 25;

        public Player()
        {
            image = new PictureBox();
            image.Parent = Engine.form;
            image.Location = new Point(Engine.form.Width - 120, Engine.form.Height / 2 + 10);
            image.Size = new Size(80, 80);
            image.BackColor = Color.Green;
        }

        public void Move()
        {
            if (isMovingLeft)
                image.Left -= speed;
            else if (isMovingRight)
                image.Left += speed;

            foreach (Control x in Engine.form.Controls)
            {
                if ((string)x.Tag == "platform")
                {
                    if (x.Top <= Engine.form.Height)
                        x.Top = x.Top + platformGravity;
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

            image.Top += 5;
            gravity = Math.Min(maxGravity, gravity + 1);
            image.Top += gravity;
            Engine.PlayerCollision();
        }
    }
}
