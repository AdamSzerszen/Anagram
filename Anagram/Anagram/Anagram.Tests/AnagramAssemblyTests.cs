using System.Collections.Generic;
using Anagram.Infrastructure.Structures;
using NUnit.Framework;

namespace Anagram.Tests
{
    [TestFixture]
    public class AnagramAssemblyTests
    {
        [Test]
        public void Count_ContainsAnagrams_ReturnsCorrectCount()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("boaster");
            var anagrams = new Queue<string>
            (
                new[]
                {
                    "boaters", "borates"
                }
            );

            foreach (var anagram in anagrams) anagramAssembly.TryAddAnagram(anagram);

            // Act
            var result = anagramAssembly.Count;

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void First_ContainsAnagrams_ReturnsFirstAnagram()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("boaster");
            var anagrams = new Queue<string>
            (
                new[]
                {
                    "boaters", "borates"
                }
            );

            foreach (var anagram in anagrams) anagramAssembly.TryAddAnagram(anagram);

            // Act
            var result = anagramAssembly.First;

            // Assert
            Assert.AreEqual("boaster", result);
        }

        [Test]
        public void ToString_ContainsIncorrectAnagrams_ReturnCorrectString()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("inlets");
            var anagrams = new Queue<string>
            (
                new[]
                {
                    "enlist", "listen", "boaster", "boaters", "borates"
                }
            );

            foreach (var anagram in anagrams) anagramAssembly.TryAddAnagram(anagram);

            // Act
            var result = anagramAssembly.ToString();

            // Assert
            Assert.AreEqual("inlets enlist listen", result);
        }

        [Test]
        public void ToString_ContainsIncorrectAnagramsWithDifferentLength_ReturnCorrectString()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("inlets");
            var anagrams = new Queue<string>
            (
                new[]
                {
                    "enlist", "listen", "boaster", "tac", "cat"
                }
            );

            foreach (var anagram in anagrams) anagramAssembly.TryAddAnagram(anagram);

            // Act
            var result = anagramAssembly.ToString();

            // Assert
            Assert.AreEqual("inlets enlist listen", result);
        }

        [Test]
        public void ToString_ContainsOnlyCorrectAnagrams_ReturnCorrectString()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("inlets");
            var anagrams = new Queue<string>
            (
                new[]
                {
                    "enlist", "listen", "silent"
                }
            );

            foreach (var anagram in anagrams) anagramAssembly.TryAddAnagram(anagram);

            // Act
            var result = anagramAssembly.ToString();

            // Assert
            Assert.AreEqual("inlets enlist listen silent", result);
        }

        [Test]
        public void ToString_ContainsOnlyIncorrectAnagrams_ReturnCorrectString()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("inlets");
            var anagrams = new Queue<string>
            (
                new[]
                {
                    "boaster", "boaters", "borates"
                }
            );

            foreach (var anagram in anagrams) anagramAssembly.TryAddAnagram(anagram);

            // Act
            var result = anagramAssembly.ToString();

            // Assert
            Assert.AreEqual("inlets", result);
        }

        [Test]
        public void TryAddAnagram_AddedCorrectAnagram_ReturnsTrue()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("inlets");

            // Act
            var result = anagramAssembly.TryAddAnagram("listen");

            // Assert
            Assert.True(result);
        }

        [Test]
        public void TryAddAnagram_AddedIncorrectAnagram_ReturnsFalse()
        {
            // Arrange
            var anagramAssembly = new AnagramAssembly("inlets");

            // Act
            var result = anagramAssembly.TryAddAnagram("cat");

            // Assert
            Assert.False(result);
        }
    }
}