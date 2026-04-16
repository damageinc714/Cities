using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesGame.Core.Models
{
    public class GameState
    {
        public List<string> UsedCities { get; set; } = new();
        public char RequiredLetter { get; set; } = '\0';
        public bool IsGameOver { get; set; }

        public int CurrentPlayerIndex { get; set; } = 0;
        public int TotalPlayers { get; set; } = 1;
    }
}