using CitiesGame.Core.Game;
using CitiesGame.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace CitiesGame.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        private CityDictionary CreateDictionary(params string[] cities)
        {
            string path = Path.GetTempFileName();
            File.WriteAllLines(path, cities, Encoding.UTF8);

            var dictionary = new CityDictionary();
            dictionary.LoadFromFile(path);

            File.Delete(path);
            return dictionary;
        }

        [TestMethod]
        public void TryMakeMove_ShouldAcceptValidFirstMove()
        {
            var dictionary = CreateDictionary("Москва", "Архангельск");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(2);

            var result = engine.TryMakeMove("Москва");

            Assert.IsTrue(result.Success);
            Assert.AreEqual('а', result.NextRequiredLetter);
            Assert.AreEqual(1, engine.State.CurrentPlayerIndex);
        }

        [TestMethod]
        public void TryMakeMove_ShouldRejectUnknownCity()
        {
            var dictionary = CreateDictionary("Москва", "Архангельск");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(2);

            var result = engine.TryMakeMove("Лондон");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Такого города нет в списке.", result.Message);
        }

        [TestMethod]
        public void TryMakeMove_ShouldRejectAlreadyUsedCity()
        {
            var dictionary = CreateDictionary("Москва", "Архангельск");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(2);
            engine.TryMakeMove("Москва");

            var result = engine.TryMakeMove("Москва");

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Этот город уже был использован.", result.Message);
        }

        [TestMethod]
        public void TryMakeMove_ShouldRejectWrongFirstLetter()
        {
            var dictionary = CreateDictionary("Москва", "Архангельск", "Курск");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(2);
            engine.TryMakeMove("Москва");

            var result = engine.TryMakeMove("Курск");

            Assert.IsFalse(result.Success);
            StringAssert.Contains(result.Message, "букву 'А'");
        }

        [TestMethod]
        public void TryMakeMove_ShouldEndWithDraw_WhenAllCitiesAreUsed()
        {
            var dictionary = CreateDictionary("Москва");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(2);

            var result = engine.TryMakeMove("Москва");

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.IsGameOver);
            Assert.IsTrue(result.IsDraw);
            StringAssert.Contains(result.Message, "игра закончена ничьёй");
        }

        [TestMethod]
        public void TryMakeMove_ShouldEndGame_WhenNoAvailableNextMoveExists()
        {
            var dictionary = CreateDictionary(
                "Жуковский",
                "Москва");

            var engine = new GameEngine(dictionary);
            engine.StartNewGame(2);

            var result = engine.TryMakeMove("Жуковский");

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.IsGameOver);
            Assert.IsFalse(result.IsDraw);
            Assert.AreEqual(0, result.WinnerPlayerIndex);
        }

        [TestMethod]
        public void SurrenderCurrentPlayer_ShouldEndGameInVsComputerMode()
        {
            var dictionary = CreateDictionary("Москва", "Архангельск");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(2);

            var result = engine.SurrenderCurrentPlayer(true);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.IsGameOver);
            Assert.AreEqual("Вы сдались. Победил компьютер.", result.Message);
        }

        [TestMethod]
        public void SurrenderCurrentPlayer_ShouldReturnWinnersInMultiplayerMode()
        {
            var dictionary = CreateDictionary("Москва", "Архангельск", "Курск");
            var engine = new GameEngine(dictionary);

            engine.StartNewGame(3);

            var result = engine.SurrenderCurrentPlayer(false);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.IsGameOver);
            StringAssert.Contains(result.Message, "Проиграл: Игрок 1");
            StringAssert.Contains(result.Message, "Победители: Игрок 2, Игрок 3");
        }
    }
}