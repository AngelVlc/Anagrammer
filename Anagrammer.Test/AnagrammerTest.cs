using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrammer.Test
{
    [TestClass]
    public class AnagrammerTest
    {
        [TestMethod]
        [ExpectedException(typeof(AnagrammerCheckException))]
        public void CheckWords_WithTwoWordsLine_ThrowsException()
        {
            var words = new[] { "bad line" };

            var anagrammer = new Anagrammer(words);

            anagrammer.CheckWords();
        }

        [TestMethod]
        [ExpectedException(typeof(AnagrammerCheckException))]
        public void CheckWords_EmptyString_ThrowsException()
        {
            var words = new[] { string.Empty };

            var anagrammer = new Anagrammer(words);

            anagrammer.CheckWords();
        }

        [TestMethod]
        [ExpectedException(typeof(AnagrammerCheckException))]
        public void CheckWords_Null_ThrowsException()
        {
            var words = new[] { "word", null };

            var anagrammer = new Anagrammer(words);

            anagrammer.CheckWords();
        }

    }
}
