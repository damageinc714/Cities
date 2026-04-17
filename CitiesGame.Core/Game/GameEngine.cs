using CitiesGame.Core.Helpers;
using CitiesGame.Core.Models;
using CitiesGame.Core.Services;

namespace CitiesGame.Core.Game
{
    public class GameEngine
    {
        private readonly CityDictionary _dictionary;

        public GameState State { get; } = new();

        public GameEngine(CityDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public void StartNewGame(int totalPlayers)
        {
            State.UsedCities.Clear();
            State.RequiredLetter = '\0';
            State.IsGameOver = false;
            State.CurrentPlayerIndex = 0;
            State.TotalPlayers = totalPlayers;
        }

        public MoveResult TryMakeMove(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return new MoveResult
                {
                    Success = false,
                    Message = "Введите название города."
                };
            }

            string normalizedCity = WordNormalizer.Normalize(cityName);

            if (!_dictionary.Contains(normalizedCity))
            {
                return new MoveResult
                {
                    Success = false,
                    Message = "Такого города нет в списке."
                };
            }

            if (State.UsedCities.Contains(normalizedCity))
            {
                return new MoveResult
                {
                    Success = false,
                    Message = "Этот город уже был использован."
                };
            }

            if (State.RequiredLetter != '\0' && normalizedCity[0] != State.RequiredLetter)
            {
                return new MoveResult
                {
                    Success = false,
                    Message = $"Город должен начинаться{Environment.NewLine}на букву '{char.ToUpper(State.RequiredLetter)}'."
                };
            }

            int playerWhoMoved = State.CurrentPlayerIndex;

            State.UsedCities.Add(normalizedCity);

            if (State.UsedCities.Count == _dictionary.Count)
            {
                State.IsGameOver = true;

                return new MoveResult
                {
                    Success = true,
                    Message = $"Вы назвали все города России,{Environment.NewLine}игра закончена ничьёй.",
                    CurrentPlayerIndex = playerWhoMoved,
                    NextPlayerIndex = playerWhoMoved,
                    IsGameOver = true,
                    IsDraw = true
                };
            }

            char nextLetter = '\0';

            foreach (char candidateLetter in WordNormalizer.GetPossibleMoveLetters(normalizedCity))
            {
                if (_dictionary.HasUnusedCitiesByLetter(candidateLetter, State.UsedCities))
                {
                    nextLetter = candidateLetter;
                    break;
                }
            }

            if (nextLetter == '\0')
            {
                State.IsGameOver = true;

                return new MoveResult
                {
                    Success = true,
                    Message = $"После города \"{cityName}\"{Environment.NewLine}не осталось доступных ходов.{Environment.NewLine}" +
                              $"Игра завершена ничьёй.",
                    CurrentPlayerIndex = playerWhoMoved,
                    NextPlayerIndex = playerWhoMoved,
                    IsGameOver = true,
                    IsDraw = true
                };
            }

            State.RequiredLetter = nextLetter;
            State.CurrentPlayerIndex = (State.CurrentPlayerIndex + 1) % State.TotalPlayers;

            return new MoveResult
            {
                Success = true,
                Message = $"Ход принят.{Environment.NewLine}Следующий город на букву '{char.ToUpper(nextLetter)}'.",
                NextRequiredLetter = nextLetter,
                CurrentPlayerIndex = playerWhoMoved,
                NextPlayerIndex = State.CurrentPlayerIndex,
                IsGameOver = false,
                IsDraw = false
            };
        }

        public MoveResult SurrenderCurrentPlayer(bool isVsComputer)
        {
            if (State.IsGameOver)
            {
                return new MoveResult
                {
                    Success = false,
                    Message = "Игра уже завершена.",
                    IsGameOver = true
                };
            }

            State.IsGameOver = true;

            int loser = State.CurrentPlayerIndex;

            if (isVsComputer)
            {
                if (loser == 0)
                {
                    return new MoveResult
                    {
                        Success = true,
                        Message = "Вы сдались. Победил компьютер.",
                        CurrentPlayerIndex = loser,
                        WinnerPlayerIndex = 1,
                        LoserPlayerIndex = 0,
                        IsGameOver = true
                    };
                }
            }

            var winners = new List<string>();

            for (int i = 0; i < State.TotalPlayers; i++)
            {
                if (i != loser)
                    winners.Add($"Игрок {i + 1}");
            }

            return new MoveResult
            {
                Success = true,
                Message = $"Игрок {loser + 1} сдался.{Environment.NewLine}" +
                          $"Проиграл: Игрок {loser + 1}.{Environment.NewLine}" +
                          $"Победители: {string.Join(", ", winners)}.",
                CurrentPlayerIndex = loser,
                LoserPlayerIndex = loser,
                IsGameOver = true
            };
        }

        public void FinishGame()
        {
            State.IsGameOver = true;
        }
    }
}