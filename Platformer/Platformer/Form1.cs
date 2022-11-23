﻿using System;
using System.Windows.Forms;

namespace Platformer
{
    public partial class Form1 : Form
    {
        public Player player;

        public Form1()
        {
            InitializeComponent();
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
                Close();
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.isMovingLeft = true;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                player.isMovingRight = true;
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (!player.isJumping)
                    player.gravity = -20;
                player.isJumping = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.isMovingLeft = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                player.isMovingRight = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Move();
            Engine.CheckIfYouLose();
        }
    }
}
