using System;
using System.Collections.Generic;

namespace AutoComplete
{
    public class Autocomplete : Trie
    {
        public List<string> GetMatches(string prefix)
        {
            var current = Root;
            foreach (var c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return new List<string>();
                }
                current = current.Children[c];
            }
            var matches = new List<string>();
            CollectMatches(current, prefix, matches);
            return matches;
        }

        private void CollectMatches(TrieNode node, string prefix, List<string> matches)
        {
            if (node.IsEndOfWord)
            {
                matches.Add(prefix);
            }
            foreach (var child in node.Children.Values)
            {
                CollectMatches(child, prefix + child.Value, matches);
            }
        }
    }
}
