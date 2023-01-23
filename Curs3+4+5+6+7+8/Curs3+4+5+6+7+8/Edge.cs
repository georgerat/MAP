using System.Drawing;

namespace Curs3_4_5_6_7_8
{
    public class Edge
    {
        public Vertex Start;
        public Vertex End;
        public float Cost;

        public Edge(string data)
        {
            string[] buffer = data.Split(' ');
            Start = Engine.Search(buffer[0], Engine.demo);
            End = Engine.Search(buffer[1], Engine.demo);
            Cost = float.Parse(buffer[2]);
        }

        public void Draw(Graphics h)
        {
            h.DrawLine(Pens.Red, Start.Location, End.Location);
            PointF M = new PointF((Start.Location.X + End.Location.X) / 2, (Start.Location.Y + End.Location.Y) / 2);
            h.DrawString(Cost.ToString(), new Font("Arial", 14), new SolidBrush(Color.Green), M);
        }

        public override string ToString()
        {
            return Cost.ToString();
        }
    }
}
