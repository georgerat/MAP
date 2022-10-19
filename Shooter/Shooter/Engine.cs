using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Shooter
{
    public static class Engine
    {
        public static Form1 form;
        public static Random random = new Random();
        public static List<Enemy> enemies = new List<Enemy>();
        public static Graphics graphics;
        public static Bitmap bitmap;

        public static int horizon = 100;

        public static void Init(Form1 f1)
        {
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);

            enemies.Add(new Enemy(100, 5, 0, 50));
            enemies.Add(new Enemy(100, 5, 0, 50));
            enemies.Add(new Enemy(100, 5, 0, 50));
            enemies.Add(new Enemy(100, 5, 0, 50));
            enemies.Add(new Enemy(100, 5, 0, 50));
        }

        public static void Shoot(Point click)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetShoot(click);
                if (enemies[i].health <= 0)
                {
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
            if (enemies.Count == 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("You win!");
                form.Close();
            }
        }

        public static Point GetRandomPoint(int size)
        {
            return new Point(random.Next(form.Width - size), horizon - size);
        }

        public static void UpdateDisplay()
        {
            graphics.Clear(Color.DimGray);

            foreach (Enemy enemy in enemies)
            {
                graphics.FillRectangle(new SolidBrush(Color.Magenta), enemy.position.X, enemy.position.Y, (int)enemy.size, (int)enemy.size);
            }
            form.pictureBox1.Image = bitmap;
        }
    }
}
