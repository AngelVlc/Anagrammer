using System;
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




    }
}
