namespace CitiesGame.Core.Game
{
    public class MoveResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public char NextRequiredLetter { get; set; }

        public int CurrentPlayerIndex { get; set; }
        public int NextPlayerIndex { get; set; }

        public bool IsGameOver { get; set; }
        public bool IsDraw { get; set; }//ничья/не ничья

        public int WinnerPlayerIndex { get; set; } = -1;
        public int LoserPlayerIndex { get; set; } = -1;
    }
}