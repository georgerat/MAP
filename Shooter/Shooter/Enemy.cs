using System.Drawing;

namespace Shooter
{
    public abstract class Enemy
    {
        public double health, speed, damage, size, positionX;
        public int spawnTime;
        public Point position;
        public Image image;

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

        public abstract void Move();
        public abstract void Draw();

        public void GetShoot(Point click)
        {
            if (click.X > position.X && click.X < position.X + size && click.Y > position.Y && click.Y < position.Y + size)
            {
                if (Engine.IsPixelTransparent(click, this))
                    return;

                if (click.Y - position.Y < size / 6)
                {
                    health -= 50;
                    Engine.graphics.DrawString("50", new Font("Arial", 12), new SolidBrush(Color.Red), click);
                }
                else
                {
                    health -= 20;
                    Engine.graphics.DrawString("20", new Font("Arial", 12), new SolidBrush(Color.White), click);
                }
                Engine.form.pictureBox1.Image = Engine.bitmap;
            }
        }
    }
}
