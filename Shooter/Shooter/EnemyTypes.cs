using System.Drawing;

namespace Shooter
{
    public class NormalEnemy : Enemy
    {
        public static Image image1 = Image.FromFile("../../images/Enemy1.png");

        public NormalEnemy(int spawnTime) : base(100, 5, 20, 50, spawnTime)
        {
            image = image1;
        }

        public override void Move()
        {
            position.Y += (int)speed;
            size += 1.0 / 4;
            positionX -= 1.0 / 8;
            position.X = (int)positionX;
        }

        public override void Draw()
        {
            Engine.graphics.DrawImage(image1, position.X, position.Y, (int)size, (int)size);
        }
    }

    public class FatEnemy : Enemy
    {
        public static Image image2 = Image.FromFile("../../images/Enemy2.png");

        public FatEnemy(int spawnTime) : base(250, 3, 50, 50, spawnTime)
        {
            image = image2;
        }

        public override void Move()
        {
            position.Y += (int)speed;
            size += 1.0 / 4;
            positionX -= 1.0 / 8;
            position.X = (int)positionX;
        }

        public override void Draw()
        {
            Engine.graphics.DrawImage(image2, position.X, position.Y, (int)size, (int)size);
        }
    }
}
