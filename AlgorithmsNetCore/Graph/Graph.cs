using System;
using System.Collections.Generic;

namespace Algorithms
{
    public partial class Graph
    {
        private int v;
        private List<int>[] adj;
        private List<int>[] edge;

        public Graph(int V)
        {
            this.v = V;
            this.adj = new List<int>[V];
            this.edge = new List<int>[V];
        }

        public int Count
        {
            get
            {
                return this.v;
            }
        }

        public void AddEdge(int a, int b)
        {
            if (a >= this.v || b >= this.v)
            {
                throw new InvalidOperationException("a or b cannot be greater than number of elements");
            }

            if (this.adj[a] == null)
            {
                this.adj[a] = new List<int>();
            }

            this.adj[a].Add(b);
        }
        public void AddEdge(int a, int b, int weight)
        {
            if (a >= this.v || b >= this.v)
            {
                throw new InvalidOperationException("a or b cannot be greater than number of elements");
            }

            if (this.adj[a] == null)
            {
                this.adj[a] = new List<int>();
            }

            if (this.edge[a] == null)
            {
                this.edge[a] = new List<int>();
            }

            this.adj[a].Add(b);
            this.edge[a].Add(weight);
        }

    }
}
