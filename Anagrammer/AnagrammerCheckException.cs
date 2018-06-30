using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Anagrammer.Test")]

namespace Anagrammer
{
    class AnagrammerCheckException : Exception
    {       
        public AnagrammerCheckException()
        {
        }

        public AnagrammerCheckException(string message)
            : base(message)
        {
        }

        public AnagrammerCheckException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
