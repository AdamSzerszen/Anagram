using System;
using System.Collections.Generic;
using System.Linq;
using Anagram.Infrastructure.Structures;

namespace Anagram.App
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var path = args.First();
                var fileLoader = new FileLoader();
                var anagrams = fileLoader.LoadAnagrams(path);
                if (anagrams != null)
                {
                    var repository = new AnagramRepository();

                    AddAllAnagramsToRepository(anagrams, repository);
                    PrintResults(repository);
                    WriteMessageAndWait("File successfully processed!");
                }
                else
                {
                    WriteMessageAndWait($"Can't find file: {path}");
                }
            }
            else
            {
                WriteMessageAndWait("Missing file path!");
            }
        }

        private static void WriteMessageAndWait(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void PrintResults(AnagramRepository repository)
        {
            var result = repository.GetAllAnagrams();
            foreach (var anagram in result) Console.WriteLine(anagram);

            Console.WriteLine($"Longest anagrams: {repository.LongestAnagram}");
            Console.WriteLine($"Most anagrams: {repository.MostAnagrams}");

            Logger.Log("File successfully processed.");
            Logger.Flush();
        }

        private static void AddAllAnagramsToRepository(IEnumerable<string> anagrams, AnagramRepository repository)
        {
            foreach (var anagram in anagrams) repository.AddAnagram(anagram);
        }
    }
}