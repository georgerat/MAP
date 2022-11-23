﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Platformer
{
    public class Player
    {
        public PictureBox image;
        public int speed = 5, gravity;
        public bool isMovingLeft, isMovingRight, isJumping = true;
        public const int maxGravity = 20;

        public Player()
        {
            image = new PictureBox();
            image.Parent = Engine.form;
            image.Location = new Point(Engine.form.Width / 2, Engine.form.Height * 3 / 4);
            image.Size = new Size(100, 100);
            image.BackColor = Color.ForestGreen;
        }

        public void Move()
        {
            if (isMovingLeft)
                image.Left -= speed;
            else if (isMovingRight)
                image.Left += speed;
            gravity = Math.Min(maxGravity, gravity + 1);
            image.Top += gravity;
            Engine.PlayerCollision();
        }
    }
}
