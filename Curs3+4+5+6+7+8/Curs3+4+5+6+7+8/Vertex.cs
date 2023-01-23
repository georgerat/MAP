using System.Drawing;

namespace Curs3_4_5_6_7_8
{
    public class Vertex
    {
        public string Name;
        public PointF Location;
        public int Idx;
        public int color = 0;

        public Vertex(string name, PointF location)
        {
            Name = name;
            Location = location;
            Idx = -1;
        }

        public Vertex(string data)
        {
            string[] t = data.Split(' ');
            Name = t[0].Trim();
            Location = new PointF(float.Parse(t[1]), float.Parse(t[2]));
        }

        public void Draw(Graphics h)
        {
            h.FillEllipse(new SolidBrush(Engine.Pal[color]), Location.X - 11, Location.Y - 11, 23, 23);
            h.DrawEllipse(Pens.Black, Location.X - 5, Location.Y - 5, 11, 11);
            h.DrawString(Name, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.Blue), Location.X, Location.Y);
        }
    }
}
