using System;

namespace AutoComplete
{
    public class Trie
    {
        public TrieNode Root;

        public Trie()
        {
            Root = new TrieNode('\0');
        }

        public void Insert(string word)
        {
            var current = Root;
            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TrieNode(c);
                }
                current = current.Children[c];
            }
            current.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            var current = Root;
            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }
            return current.IsEndOfWord;
        }

        public bool Remove(string word)
        {
            var nodeToRemove = FindNode(Root, word);
            if (nodeToRemove == null || !nodeToRemove.IsEndOfWord)
            {
                return false; // word not found or not complete
            }
            if (nodeToRemove.Children.Count > 0)
            {
                nodeToRemove.IsEndOfWord = false; // mark node as not complete
                return true;
            }
            var currentNode = Root;
            var parent = Root;
            foreach (var c in word)
            {
                parent = currentNode;
                currentNode = currentNode.Children[c];
                if (currentNode.Children.Count > 1)
                {
                    parent = currentNode;
                }
            }
            parent.Children.Remove(word[word.Length - 1]);
            return true;
        }

        private TrieNode FindNode(TrieNode node, string word)
        {
            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return null; // node not found
                }
                node = node.Children[c];
            }
            return node;
        }

    }
}
