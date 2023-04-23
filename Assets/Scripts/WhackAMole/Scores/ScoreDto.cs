using System;
using System.Collections.Generic;

namespace WAM.WhackAMole.Scores
{
    [Serializable]
    public class ScoreDto
    {
        public List<HighscoreEntry> Highscores;
    }
}