using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Anagrammer.Test")]

namespace Anagrammer
{
    /// <summary>
    /// 
    /// </summary>
    class Anagrammer
    {
        private string[] _words;

        public Anagrammer(string[] words)
        {
            _words = words;
        }

        /// <summary>
        /// Checks if the words array contains only single words.
        /// </summary>
        public void CheckWords()
        {
            for (int i = 0; i < _words.Length; i++)
            {
                if (string.IsNullOrEmpty(_words[i]))
                {
                    throw new AnagrammerCheckException(string.Format(Resources.LineWithEmptyString, i));
                }

                var parts = _words[i].Split(' ');
                if (parts.Length > 1)
                {
                    throw new AnagrammerCheckException(string.Format(Resources.LineWithTwoWords, i, parts.Length));
                }
            }
        }

        public List<string> GetAnagramsByWordLength()
        {
            var dictionary = GetWordsDictionay();

            var result = new List<string>();

            foreach (var word in dictionary.Keys.OrderByDescending(key => key.Length))
            {
                result.Add(string.Join(" ", dictionary[word].OrderBy(i => i).ToArray()));
            }

            return result;
        }

        public List<string> GetAnagramsByWordsNumber()
        {
            var dictionary = GetWordsDictionay();

            var result = new List<string>();

            foreach (var value in dictionary.Values.OrderByDescending(value => value.Count()))
            {
                result.Add(string.Join(" ", value.OrderBy(i => i).ToArray()));
            }

            return result;
        }

        private Dictionary<string, List<string>> GetWordsDictionay()
        {
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var l in _words)
            {
                var sorted = string.Concat(l.OrderBy(c => c));

                List<string> found;

                if (!dictionary.TryGetValue(sorted, out found))
                {
                    found = new List<string>();
                    dictionary.Add(sorted, found);
                }

                found.Add(l);
            }

            return dictionary;
        }

    }
}
