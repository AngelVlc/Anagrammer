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
        public void CheckWords_WithEmptyString_ThrowsException()
        {
            var words = new[] { string.Empty };

            var anagrammer = new Anagrammer(words);

            anagrammer.CheckWords();
        }

        [TestMethod]
        [ExpectedException(typeof(AnagrammerCheckException))]
        public void CheckWords_WithNull_ThrowsException()
        {
            var words = new[] { "word", null };

            var anagrammer = new Anagrammer(words);

            anagrammer.CheckWords();
        }

        [TestMethod]
        [ExpectedException(typeof(AnagrammerCheckException))]
        public void CheckWords_WithWordWhichEndsWithSpace_ThrowsException()
        {
            var words = new[] { "word " };

            var anagrammer = new Anagrammer(words);

            anagrammer.CheckWords();
        }

        [TestMethod]
        public void GetAnagramsByWordsNumber_WithWords_ReturnsDictionary()
        {
            var words = new[] { "rtd", "trd", "asdsda", "giotr", "muyyu" };

            var anagrammer = new Anagrammer(words);

            var result = anagrammer.GetAnagramsByWordsNumber();

            Assert.IsTrue(result[0].IndexOf(words[0]) >= 0);
            Assert.IsTrue(result.Count == 4);
        }

        [TestMethod]
        public void GetAnagramsByWordLength_WithWords_ReturnsDictionary()
        {
            var words = new[] { "enlist", "listen", "rtd", "trd", "muyyu" };

            var anagrammer = new Anagrammer(words);

            var result = anagrammer.GetAnagramsByWordLength();

            Assert.IsTrue(result[0].IndexOf(words[0]) >= 0);
            Assert.IsTrue(result.Count == 3);
        }

    }
}
