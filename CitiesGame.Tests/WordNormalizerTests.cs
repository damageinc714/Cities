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
            string input = "  БудЁнновск  ";

            string result = WordNormalizer.Normalize(input);

            Assert.AreEqual("буденновск", result);
        }

        [TestMethod]
        public void GetPossibleMoveLetters_ShouldSkipIgnoredLetters()
        {
            string city = "Нягань";

            var result = WordNormalizer.GetPossibleMoveLetters(city).ToList();

            CollectionAssert.AreEqual(
                new[] { 'н', 'а', 'г', 'я', 'н' },
                result);
        }
    }
}