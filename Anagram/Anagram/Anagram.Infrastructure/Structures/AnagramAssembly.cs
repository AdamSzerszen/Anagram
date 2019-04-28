using System.Collections.Generic;
using System.Linq;

namespace Anagram.Infrastructure.Structures
{
    public class AnagramAssembly
    {
        private readonly string _sortedLetters;
        private readonly List<string> _anagrams;

        public string First => _anagrams.First();
        public int Count => _anagrams.Count;

        public AnagramAssembly(string word)
        {
            _sortedLetters = string.Concat(word.OrderBy(character => character));
            _anagrams = new List<string>
            {
                word
            };
        }

        public bool TryAddAnagram(string word)
        {
            if (!IsAnagram(word)) return false;

            _anagrams.Add(word);
            return true;
        }

        public override string ToString()
        {
            return string.Join(" ", _anagrams);
        }

        private bool IsAnagram(string word)
        {
            if (!IsSameLength(word)) return false;
            var sortedWord = string.Concat(word.OrderBy(character => character));

            return string.CompareOrdinal(_sortedLetters, sortedWord) == 0;
        }

        private bool IsSameLength(string word)
        {
            return _sortedLetters.Length == word.Length;
        }
    }
}