using CitiesGame.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text;

namespace CitiesGame.Tests
{
    [TestClass]
    public class CityDictionaryTests
    {
        private string CreateTempCitiesFile(params string[] cities)
        {
            string path = Path.GetTempFileName();
            File.WriteAllLines(path, cities, Encoding.UTF8);
            return path;
        }

        [TestMethod]
        public void LoadFromFile_ShouldLoadUniqueNormalizedCities()
        {
            string path = CreateTempCitiesFile(
                "Москва",
                "москва",
                "Курск",
                "Курск ",
                " Артём");

            var dictionary = new CityDictionary();

            dictionary.LoadFromFile(path);

            Assert.AreEqual(3, dictionary.Count);
            Assert.IsTrue(dictionary.Contains("Москва"));
            Assert.IsTrue(dictionary.Contains("Артем"));
            Assert.IsTrue(dictionary.Contains("Курск"));

            File.Delete(path);
        }

        [TestMethod]
        public void GetCitiesByLetter_ShouldReturnOnlyMatchingCities()
        {
            string path = CreateTempCitiesFile(
                "Москва",
                "Мурманск",
                "Курск",
                "Казань");

            var dictionary = new CityDictionary();
            dictionary.LoadFromFile(path);

            var result = dictionary.GetCitiesByLetter('м').ToList();

            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, "москва");
            CollectionAssert.Contains(result, "мурманск");

            File.Delete(path);
        }

        [TestMethod]
        public void HasUnusedCitiesByLetter_ShouldReturnFalse_WhenAllMatchingCitiesAreUsed()
        {
            string path = CreateTempCitiesFile(
                "Москва",
                "Мурманск",
                "Курск");

            var dictionary = new CityDictionary();
            dictionary.LoadFromFile(path);

            var used = new[] { "москва", "мурманск" };

            bool result = dictionary.HasUnusedCitiesByLetter('м', used);

            Assert.IsFalse(result);

            File.Delete(path);
        }
    }
}