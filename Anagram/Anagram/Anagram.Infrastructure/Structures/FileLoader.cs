using System;
using System.Collections.Generic;
using System.IO;

namespace Anagram.Infrastructure.Structures
{
    public class FileLoader
    {
        public List<string> LoadAnagrams(string path)
        {
            if (!File.Exists(path))
            {
                Logger.Log($"Can't find file: {path}.");
                return null;
            }

            var anagrams = new List<string>();

            using (var file = new StreamReader(path))
            {
                Logger.Log($"Loading anagrams from file.");
                try
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var processedWord = ProcessWord(line);
                        anagrams.Add(processedWord);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Exception occured. Exception message: {ex.Message}");
                }
            }

            return anagrams;
        }

        private string ProcessWord(string line)
        {
            var processedWord = line.Trim();
            processedWord = processedWord.ToLower();
            return processedWord;
        }
    }
}