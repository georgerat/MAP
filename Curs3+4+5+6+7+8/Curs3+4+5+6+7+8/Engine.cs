using System.Drawing;
using System.Windows.Forms;

namespace Curs3_4_5_6_7_8
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color color = Color.DimGray;
        public static Graf demo, ACM;
        public static Color[] Pal = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Orange };

        public static void initGraph(PictureBox t)
        {
            display = t;
            bmp = new Bitmap(t.Width, t.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);
        }

        public static void Refresh()
        {
            display.Image = bmp;
        }

        public static void Clear()
        {
            grp.Clear(color);
        }

        public static Vertex Search(string name, Graf g)
        {
            foreach (Vertex vertex in g.Vertices)
            {
                if (vertex.Name == name)
                    return vertex;
            }
            return null;
        }
    }
}
