using System;
using System.Collections.Generic;

namespace Algorithms
{
    public partial class Graph
    {
        public void BFS(int s = 0, Action<int> callback = null)
        {
            if (s >= this.Count)
            {
                throw new InvalidOperationException("s cannot be greater than Count");
            }

            bool[] visited = new bool[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                visited[i] = false;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;

            int v = -1;
            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                callback?.Invoke(v);

                foreach (int i in this.adj[v])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
