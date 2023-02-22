using System.Collections.Generic;

namespace AutoComplete
{
    public class TrieNode
    {
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode(char value)
        {
            Value = value;
            IsEndOfWord = false;
            Children = new Dictionary<char, TrieNode>();
        }
    }
}
