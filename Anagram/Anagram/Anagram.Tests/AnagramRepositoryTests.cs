using Anagram.Infrastructure.Structures;
using NUnit.Framework;

namespace Anagram.Tests
{
    [TestFixture]
    public class AnagramRepositoryTests
    {
        [Test]
        public void AddAnagram_AddedExistingAnagram_AnagramAssembliesContainsAddedAnagram()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();

            // Act
            anagramRepository.AddAnagram("enlist");
            var resultBefore = anagramRepository.GetAllAnagrams();


            anagramRepository.AddAnagram("silent");
            var resultAfter = anagramRepository.GetAllAnagrams();

            // Assert
            Assert.IsTrue(resultBefore.Contains("enlist"));
            Assert.IsFalse(resultBefore.Contains("silent"));
            Assert.IsTrue(resultAfter.Contains("enlist silent"));
        }

        [Test]
        public void AddAnagram_AddedExistingAnagram_AnagramAssembliesNotIncrementedInRepository()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();

            // Act
            anagramRepository.AddAnagram("enlist");
            var resultBefore = anagramRepository.GetAllAnagrams().Count;


            anagramRepository.AddAnagram("silent");
            var resultAfter = anagramRepository.GetAllAnagrams().Count;

            // Assert
            Assert.AreEqual(resultBefore, resultAfter);
        }

        [Test]
        public void AddAnagram_AddedNewAnagram_AnagramAssembliesContainsAddedAnagram()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();
            var anagram = "enlist";

            // Act
            var resultBefore = anagramRepository.GetAllAnagrams().Contains(anagram);

            anagramRepository.AddAnagram(anagram);

            var resultAfter = anagramRepository.GetAllAnagrams().Contains(anagram);

            // Assert
            Assert.IsFalse(resultBefore);
            Assert.IsTrue(resultAfter);
        }

        [Test]
        public void AddAnagram_AddedNewAnagram_AnagramAssembliesIncrementedInRepository()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();

            // Act
            var resultBefore = anagramRepository.GetAllAnagrams().Count;

            anagramRepository.AddAnagram("enlist");

            var resultAfter = anagramRepository.GetAllAnagrams().Count;

            // Assert
            Assert.AreEqual(resultBefore + 1, resultAfter);
        }

        [Test]
        public void LongestAnagram_ContainsAnagramAssemblies_ReturnsLongestAnagram()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();
            anagramRepository.AddAnagram("enlist");
            anagramRepository.AddAnagram("boaster");
            anagramRepository.AddAnagram("sinks");
            anagramRepository.AddAnagram("cat");

            // Act
            var result = anagramRepository.LongestAnagram;

            // Assert
            Assert.AreEqual("boaster", result);
        }

        [Test]
        public void LongestAnagram_ContainsAnagramAssemblies_ReturnsLongestAnagrams()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();
            anagramRepository.AddAnagram("enlist");
            anagramRepository.AddAnagram("boaster");
            anagramRepository.AddAnagram("fresher");
            anagramRepository.AddAnagram("sinks");
            anagramRepository.AddAnagram("cat");

            // Act
            var result = anagramRepository.LongestAnagram;

            // Assert
            Assert.AreEqual("boaster fresher", result);
        }

        [Test]
        public void MostAnagrams_ContainsAnagramAssemblies_ReturnsMostAnagrams()
        {
            // Arrange
            var anagramRepository = new AnagramRepository();
            anagramRepository.AddAnagram("enlist");
            anagramRepository.AddAnagram("inlets");
            anagramRepository.AddAnagram("fresher");
            anagramRepository.AddAnagram("sinks");
            anagramRepository.AddAnagram("cat");

            // Act
            var result = anagramRepository.MostAnagrams;

            // Assert
            Assert.AreEqual("enlist inlets", result);
        }
    }
}