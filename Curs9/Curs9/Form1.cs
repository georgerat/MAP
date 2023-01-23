using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Curs9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graph g = new Graph();

        private void Form1_Load(object sender, EventArgs e)
        {
            g.load(@"../../TextFile1.txt");
            List<string> list = g.view(g.matrix);
            foreach (string s in list)
                listBox1.Items.Add(s);
            listBox1.Items.Add('\n');
            g.Roy_Warshall();
            List<string> list2 = g.view(g.mdrumuri);
            foreach (string s in list2)
                listBox1.Items.Add(s);
            listBox1.Items.Add('\n');
            List<string> list3 = g.CTC();
            foreach (string s in list3)
                listBox1.Items.Add(s);
        }
    }
}
