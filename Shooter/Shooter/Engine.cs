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
        public static List<Enemy> enemies = new List<Enemy>(), wave = new List<Enemy>();
        public static Graphics graphics;
        public static Bitmap bitmap;

        public static int horizon = 300;
        public static double fortHealth = 100, time = 0;

        public static void Init(Form1 f1)
        {
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);

            wave.Add(new Enemy(100, 5, 20, 50, 0));
            wave.Add(new Enemy(100, 5, 20, 50, 15));
            wave.Add(new Enemy(100, 5, 20, 50, 30));
            wave.Add(new Enemy(100, 5, 20, 50, 45));
            wave.Add(new Enemy(100, 5, 20, 50, 60));
        }

        public static void Tick()
        {
            time++;
            form.TimeLabel.Text = (time / 10).ToString();

            if (wave.Count > 0 && wave[0].spawnTime <= time)
            {
                enemies.Add(wave[0]);
                wave.RemoveAt(0);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Move();
                if (enemy.position.Y >= form.Height)
                {
                    fortHealth -= enemy.damage;
                    form.HealthLabel.Text = $"Health {fortHealth}";
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }

            if (fortHealth <= 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("You lose!");
                form.Close();
            }

            UpdateDisplay();
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
            if (wave.Count == 0 && enemies.Count == 0)
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
            graphics.DrawImage(form.background, 0, 0, form.Width, form.Height);

            foreach (Enemy enemy in enemies)
            {
                graphics.DrawImage(form.enemy1, enemy.position.X, enemy.position.Y, (int)enemy.size, (int)enemy.size);
            }
            form.pictureBox1.Image = bitmap;
        }
    }
}
