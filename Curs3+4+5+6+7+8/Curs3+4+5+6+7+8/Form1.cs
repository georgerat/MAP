using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Curs3_4_5_6_7_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.initGraph(pictureBox1);
            Engine.demo = new Graf();
            Engine.demo.LoadFromFile(@"../../TextFile1.txt");
            Engine.demo.Color();
            List<string> t = Engine.demo.View();
            Engine.demo.Draw(Engine.grp);
            Engine.Refresh();
            Engine.demo.Sort();
            foreach (Edge edge in Engine.demo.Edges)
                listBox2.Items.Add(edge.ToString());

            foreach (string s in t)
            {
                listBox1.Items.Add(s);
            }

            //listBox2.Items.Add(Engine.demo.Color());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = "";
            List<int> t = Engine.demo.BFS(3);
            foreach (int i in t)
                x += i + " ";
            listBox2.Items.Add(x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = "";
            List<int> t = Engine.demo.DFS(3);
            foreach (int i in t)
                x += i + " ";
            listBox2.Items.Add(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ns = 1;
            float[] t = Engine.demo.Dijkstra(ns);

            for (int i = 0; i < Engine.demo.Vertices.Count; i++)
            {
                listBox2.Items.Add(ns + " -> " + i + " : " + t[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ns = 1;
            int[] t = Engine.demo.Hamilton(ns);
            string s = "";

            for (int i = 0; i < Engine.demo.Vertices.Count; i++)
            {
                s += t[i] + " ";
            }
            listBox2.Items.Add(s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ns = 1;
            bool t = Engine.demo.Cycledetect(ns);
            listBox2.Items.Add(t);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Engine.ACM = new Graf(Engine.demo);
            Engine.Clear();
            Engine.demo.Sort();
            Engine.ACM.addEdge(Engine.demo.Edges[0]);
            Engine.ACM.addEdge(Engine.demo.Edges[1]);
            for (int i = 2; i < Engine.demo.Edges.Count; i++)
            {
                Engine.ACM.addEdge(Engine.demo.Edges[i]);
                Engine.ACM.Calculus();
                if (Engine.ACM.Cycledetect(i))
                    Engine.ACM.Remove();
            }
            Engine.Refresh();
            Engine.ACM.Draw(Engine.grp);
        }
    }
}
