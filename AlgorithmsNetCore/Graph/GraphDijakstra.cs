using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public partial class Graph
    {
        public int[] Dijakstra(int src)
        {
            if (src >= this.Count)
            {
                throw new InvalidOperationException("s cannot be greater than Count");
            }

            int[] dist = new int[this.Count];
            bool[] visited = new bool[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            dist[src] = 0;

            for (int i = 0; i < this.Count - 1; i++)
            {
                int j = this.MinDistance(dist, visited);
                visited[j] = true;
                for (int l = 0; l < this.adj[j].Count; l++)
                {
                    int k = this.adj[j][l];

                    if (!visited[k] && dist[j] != int.MaxValue && dist[j] + this.edge[j][l] < dist[k])
                    {
                        dist[k] = dist[j] + this.edge[j][l];
                    }
                }
            }

            return dist;
        }

        public void PrintDistance(int[] dist, int src)
        {
            if (src >= this.Count)
            {
                throw new InvalidOperationException("s cannot be greater than Count");
            }

            Console.WriteLine("Distance from source: {0}", src);
            for (int i = 0; i < dist.Length; i++)
            {
                Console.WriteLine("{0} => {1}", i, dist[i]);
            }
        }

        private int MinDistance(int[] dist, bool[] visited)
        {
            int min = int.MaxValue;
            int min_index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (!visited[i] && dist[i] < min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }

            return min_index;
        }
    }
}
