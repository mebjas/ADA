using System;

namespace Algorithms
{
    public partial class Graph
    {
        public void DFS(int s = 0, Action<int> callback = null)
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

            visited[s] = true;
            this.DFS(s, callback, visited);
        }

        private void DFS(int s, Action<int> callback, bool[] visited)
        {
            callback?.Invoke(s);
            foreach (int i in this.adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    this.DFS(i, callback, visited);
                }
            }
        }
    }
}
