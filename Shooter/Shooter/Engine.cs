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
            wave1.Add(new NormalEnemy(0));
            wave1.Add(new NormalEnemy(20));
            wave1.Add(new NormalEnemy(35));
            wave1.Add(new NormalEnemy(45));
            wave1.Add(new NormalEnemy(55));

            var wave2 = new List<Enemy>();
            wave2.Add(new NormalEnemy(0));
            wave2.Add(new NormalEnemy(10));
            wave2.Add(new NormalEnemy(17));
            wave2.Add(new NormalEnemy(22));
            wave2.Add(new NormalEnemy(30));
            wave2.Add(new FatEnemy(35));
            wave2.Add(new NormalEnemy(42));
            wave2.Add(new FatEnemy(50));

            waves.Add(wave1);
            waves.Add(wave2);
            wave = wave1;
        }

        public static void Tick()
        {
            time++;
            form.TimeLabel.Text = ((int)(time / 10)).ToString();

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
                    form.HealthLabel.Text = $"Health: {fortHealth}/100";
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
                enemy.Draw();
            }
            form.pictureBox1.Image = bitmap;
        }

        public static void BlurBackground()
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Black)), 0, 0, form.Width, form.Height);
            form.pictureBox1.Image = bitmap;
        }

        public static bool IsPixelTransparent(Point click, Enemy enemy)
        {
            int x = click.X - enemy.position.X;
            int y = click.Y - enemy.position.Y;
            Bitmap bitmap = new Bitmap((int)enemy.size, (int)enemy.size);
            Graphics grp = Graphics.FromImage(bitmap);
            grp.DrawImage(enemy.image, 0, 0, (int)enemy.size, (int)enemy.size);

            return bitmap.GetPixel(x, y).ToArgb() == 0;
        }
    }
}
