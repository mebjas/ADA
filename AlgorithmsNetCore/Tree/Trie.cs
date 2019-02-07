using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class TrieNode
    {
        public bool IsEOW;

        //// TODO: make private
        public TrieNode[] children;

        public TrieNode()
        {
            this.IsEOW = false;
            this.children = new TrieNode[26];
            for (int i = 0; i < 26; i++)
            {
                this.children[i] = null;
            }
        }
    }

    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode();
        }

        public void Insert(string s)
        {
            this.Insert(this.root, s);
        }

        public bool Exists(string s)
        {
            return this.Exists(this.root, s);
        }

        private void Insert(TrieNode node, string s, int i = 0)
        {
            if (node.children[s[i] - 'a'] == null)
            {
                node.children[s[i] - 'a'] = new TrieNode();
            }

            if (i == s.Length - 1)
            {
                node.children[s[i] - 'a'].IsEOW = true;
                return;
            }

            this.Insert(node.children[s[i] - 'a'], s, i + 1);
        }

        private bool Exists(TrieNode node, string s, int i = 0)
        {
            if (node == null)
            {
                return false;
            }

            if (i == s.Length)
            {
                return node.IsEOW;
            }

            return this.Exists(node.children[s[i] - 'a'], s, i + 1);
        }
    }
}
