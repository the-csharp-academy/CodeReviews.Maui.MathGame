using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.PreviousGames
{
    internal record struct GameRecord
    {
        public string GameType;
        public string Score;
        internal GameRecord(string gameType, string score)
        {
            GameType = gameType; 
            Score = score;
        }
    }
}
