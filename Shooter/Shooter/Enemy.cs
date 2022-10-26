﻿using System.Drawing;

namespace Shooter
{
    public class Enemy
    {
        public double health, speed, damage, size, positionX;
        public int spawnTime;
        public Point position;

        public Enemy(double health, double speed, double damage, double size, int spawnTime)
        {
            this.health = health;
            this.speed = speed;
            this.damage = damage;
            this.size = size;
            this.spawnTime = spawnTime;
            position = Engine.GetRandomPoint((int)size);
            positionX = position.X;
        }

        public void Move()
        {
            position.Y += (int)speed;
            size += 1.0 / 4;
            positionX -= 1.0 / 8;
            position.X = (int)positionX;
        }

        public void GetShoot(Point click)
        {
            if (click.X > position.X && click.X < position.X + size && click.Y > position.Y && click.Y < position.Y + size)
            {
                health -= 20;
                Engine.graphics.DrawString("20", new Font("Arial", 12), new SolidBrush(Color.White), click);
                Engine.form.pictureBox1.Image = Engine.bitmap;
            }
        }
    }
}
