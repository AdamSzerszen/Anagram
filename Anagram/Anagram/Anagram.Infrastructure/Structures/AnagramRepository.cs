using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anagram.Infrastructure.Structures
{
    public class AnagramRepository
    {
        private readonly List<AnagramAssembly> _anagramAssemblies;

        public string LongestAnagram
        {
            get
            {
                var result = _anagramAssemblies.GroupBy(anagramAssembly => anagramAssembly.First.Length)
                    .OrderByDescending(anagramAssemblySet => anagramAssemblySet.Key)
                    .FirstOrDefault()
                    ?.Select(anagramAssembly => anagramAssembly.First);
                var anagrams = string.Join(" ", result);
                return anagrams;
            }
        }


        public string MostAnagrams
        {
            get
            {
                var result = _anagramAssemblies.GroupBy(anagramAssembly => anagramAssembly.Count)
                    .OrderByDescending(anagramAssembly => anagramAssembly.Key)
                    .FirstOrDefault()
                    ?.Select(anagramAssembly => anagramAssembly.ToString());

                var anagrams = string.Join("\n", result);
                return anagrams;
            }
        }

        public AnagramRepository()
        {
            _anagramAssemblies = new List<AnagramAssembly>();
            Logger.Log("Repository created.");            
        }

        public void AddAnagram(string word)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            try
            {
                TryAddAnagram(word, cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                Logger.Log($"Anagram {word} added to existing anagrams assembly.");
            }
            finally
            {
                if (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    _anagramAssemblies.Add(new AnagramAssembly(word));
                    Logger.Log("Anagram assembly created.");
                    Logger.Log($"Anagram {word} added to existing anagrams assembly.");
                }
            }
        }

        public List<string> GetAllAnagrams()
        {
            var anagrams = _anagramAssemblies.Select(anagram => anagram.ToString());
            return anagrams.ToList();
        }

        private void TryAddAnagram(string word, CancellationTokenSource cancellationTokenSource)
        {
            var options = CreateParallelOptions(cancellationTokenSource);

            Parallel.ForEach(_anagramAssemblies, options, (anagramAssembly, state) =>
            {
                options.CancellationToken.ThrowIfCancellationRequested();

                var successfullyAdded = anagramAssembly.TryAddAnagram(word);
                if (successfullyAdded)
                {
                    cancellationTokenSource.Cancel();
                }
            });
        }

        private ParallelOptions CreateParallelOptions(CancellationTokenSource cancellationTokenSource)
        {
            var options = new ParallelOptions
            {
                CancellationToken = cancellationTokenSource.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            return options;
        }
    }
}