using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Curs3_4_5_6_7_8
{
    public class Graf
    {
        public List<Vertex> Vertices;
        public List<Edge> Edges;
        public int[,] Matrix;
        private List<int> toR;
        public static float inf = 1e10f;
        public int[] v;

        public Graf()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public Graf(Graf toClone)
        {
            Edges = new List<Edge>();
            this.Vertices = toClone.Vertices;
        }

        public void LoadFromFile(string filename)
        {
            TextReader reader = new StreamReader(filename);

            int n = int.Parse(reader.ReadLine());
            Matrix = new int[n, n];

            string buffer;

            for (int i = 0; i < n; i++)
            {
                buffer = reader.ReadLine();
                Vertex local = new Vertex(buffer);
                local.Idx = i;
                Vertices.Add(local);
            }

            while ((buffer = reader.ReadLine()) != null)
            {
                Edge edge = new Edge(buffer);
                Edges.Add(edge);
            }

            reader.Close();

            foreach (Edge edge in Edges)
            {
                Matrix[edge.Start.Idx, edge.End.Idx] = (int)edge.Cost;
                Matrix[edge.End.Idx, edge.Start.Idx] = (int)edge.Cost;
            }
        }

        public List<int> BFS(int ns)
        {
            List<int> toR = new List<int>();
            Queue A = new Queue();

            bool[] v = new bool[Vertices.Count];
            v[ns] = true;
            A.Push(ns);
            while (!A.IsEmpty())
            {
                int x = A.Pop();
                toR.Add(x);
                v[x] = true;
                for (int i = 0; i < Vertices.Count; i++)
                {
                    if (Matrix[x, i] != 0 && !v[i])
                    {
                        v[i] = true;
                        A.Push(i);
                    }
                }
            }
            return toR;
        }

        public List<int> DFS(int ns)
        {
            bool[] v = new bool[Vertices.Count];
            v[ns] = true;
            toR = new List<int>();
            DFS_Utiles(ns, v);
            return toR;
        }

        private void DFS_Utiles(int ns, bool[] v)
        {
            toR.Add(ns);
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Matrix[ns, i] != 0 && !v[i])
                {
                    v[i] = true;
                    DFS_Utiles(i, v);
                }
            }
        }

        public List<string> View()
        {
            List<string> t = new List<string>();
            string b;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                b = "";
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    b += Matrix[i, j];
                }
                t.Add(b);
            }
            return t;
        }

        public void Draw(Graphics h)
        {
            foreach (Vertex v in Vertices)
            {
                v.Draw(h);
            }
            foreach (Edge e in Edges)
            {
                e.Draw(h);
            }
        }

        public void Color()
        {
            int n = Vertices.Count;
            int[] colors = new int[n];

            for (int i = 0; i < n; i++)
            {
                colors[i] = -1;
            }

            colors[0] = 0;
            bool[] lc = new bool[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    lc[j] = false;
                }

                for (int j = 0; j < n; j++)
                {
                    if (Matrix[i, j] != 0)
                    {
                        if (colors[j] != -1)
                            lc[colors[j]] = true;
                    }
                }

                int idx = 0;
                while (lc[idx])
                {
                    idx++;
                }
                colors[i] = idx;
            }

            //string t = "";
            //for (int i = 0; i < n; i++)
            //{
            //    t += colors[i] + " ";
            //}
            //return t;

            for (int i = 0; i < n; i++)
            {
                Vertices[i].color = colors[i];
            }
        }

        public float[] Dijkstra(int ns)
        {
            float[] D = new float[Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                D[i] = inf;
            }

            Queue<int> A = new Queue<int>();

            D[ns] = 0;
            A.Enqueue(ns);

            while (A.Count > 0)
            {
                int t = A.Dequeue();
                for (int i = 0; i < Vertices.Count; i++)
                {
                    if (Matrix[t, i] != 0)
                    {
                        if (D[t] + Matrix[t, i] < D[i])
                        {
                            D[i] = D[t] + Matrix[t, i];
                            A.Enqueue(i);
                        }
                    }
                }
            }

            return D;
        }

        public void bk(int k, int n, int[] s, bool[] b)
        {
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (Matrix[s[i], s[i + 1]] == 0)
                        ok = false;
                }
                if (ok)
                {
                    for (int i = 0; i < n; i++)
                    {
                        v[i] = s[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        bk(k + 1, n, s, b);
                        b[i] = false;
                    }
                }
            }
        }

        public int[] Hamilton(int ns)
        {
            v = new int[Vertices.Count];
            int[] s = new int[Vertices.Count];
            bool[] b = new bool[Vertices.Count];
            bk(0, Vertices.Count, s, b);
            return v;
        }

        public bool Cycledetect(int ns)
        {
            bool[] v = new bool[Vertices.Count];
            for (int i = 0; i < Vertices.Count; i++)
            {
                v[i] = false;
            }
            return CycledetectUtils(ns, v, -1);
        }

        public bool CycledetectUtils(int ns, bool[] b, int parent)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Matrix[ns, i] != 0)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        CycledetectUtils(i, b, ns);
                    }
                    else
                        if (parent != i)
                        return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            Edges.Sort(delegate (Edge A, Edge B) { return A.Cost.CompareTo(B.Cost); });
        }

        public void Calculus()
        {
            Matrix = new int[Vertices.Count, Vertices.Count];
            foreach (Edge edge in Edges)
            {
                Matrix[edge.Start.Idx, edge.End.Idx] = (int)edge.Cost;
                Matrix[edge.End.Idx, edge.Start.Idx] = (int)edge.Cost;
            }
        }

        public void addEdge(Edge toAdd)
        {
            Edges.Add(toAdd);
        }

        public void Remove()
        {
            Edges.RemoveAt(Edges.Count - 1);
        }
    }
}
