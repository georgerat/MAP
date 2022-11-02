﻿using System;
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
        public static List<List<Enemy>> waves = new List<List<Enemy>>();
        public static Graphics graphics;
        public static Bitmap bitmap;

        public static int horizon = 300, Wave = 1;
        public static double fortHealth = 100, time = 0;

        public static void Init(Form1 f1)
        {
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);

            var wave1 = new List<Enemy>();
            wave1.Add(new Enemy(100, 5, 20, 50, 0));
            wave1.Add(new Enemy(100, 5, 20, 50, 15));
            wave1.Add(new Enemy(100, 5, 20, 50, 30));
            wave1.Add(new Enemy(100, 5, 20, 50, 45));
            wave1.Add(new Enemy(100, 5, 20, 50, 60));

            var wave2 = new List<Enemy>();
            wave2.Add(new Enemy(100, 5, 20, 50, 0));
            wave2.Add(new Enemy(100, 5, 20, 50, 10));
            wave2.Add(new Enemy(100, 5, 20, 50, 17));
            wave2.Add(new Enemy(100, 5, 20, 50, 22));
            wave2.Add(new Enemy(100, 5, 20, 50, 30));
            wave2.Add(new Enemy(100, 5, 20, 50, 35));
            wave2.Add(new Enemy(100, 5, 20, 50, 42));
            wave2.Add(new Enemy(100, 5, 20, 50, 50));

            waves.Add(wave1);
            waves.Add(wave2);
            wave = wave1;
        }

        public static void Tick()
        {
            time++;
            form.TimeLabel.Text = (time / 10).ToString();

            if (wave.Count == 0 && enemies.Count == 0)
            {
                if (Wave < waves.Count)
                {
                    NextWave();
                }
                else
                {
                    form.timer1.Enabled = false;
                    MessageBox.Show("You win!");
                    form.Close();
                }
            }

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
                    form.HealthLabel.Text = $"Health: {fortHealth}";
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }

            if (fortHealth <= 0)
            {
                form.backgroundSound.Stop();
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
        }

        private static void NextWave()
        {
            Wave++;
            wave = waves[Wave - 1];
            time = 0;
            form.WaveLabel.Text = $"Wave: {Wave}";
        }

        public static Point GetRandomPoint(int size)
        {
            return new Point(random.Next(form.Width - size), horizon - size);
        }

        public static void UpdateDisplay()
        {
            graphics.DrawImage(form.background, 0, 0, form.Width, form.Height);

            enemies.Sort((e1, e2) => e1.position.Y - e2.position.Y);

            foreach (Enemy enemy in enemies)
            {
                graphics.DrawImage(form.enemy1, enemy.position.X, enemy.position.Y, (int)enemy.size, (int)enemy.size);
            }
            form.pictureBox1.Image = bitmap;
        }
    }
}