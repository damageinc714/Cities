using CitiesGame.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CitiesGame.Tests
{
    [TestClass]
    public class WordNormalizerTests
    {
        [TestMethod]
        public void Normalize_ShouldConvertToLowercase_TrimAndReplaceYo()
        {
            string input = "  АртЁм  ";

            string result = WordNormalizer.Normalize(input);

            Assert.AreEqual("артем", result);
        }

        [TestMethod]
        public void GetPossibleMoveLetters_ShouldSkipIgnoredLetters()
        {
            string city = "Жуковский";

            var result = WordNormalizer.GetPossibleMoveLetters(city).ToList();

            CollectionAssert.AreEqual(
                new[] { 'и', 'к', 'с', 'в', 'о', 'к', 'у', 'ж' },
                result);
        }
    }
}