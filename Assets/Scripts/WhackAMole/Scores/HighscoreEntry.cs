using System;

namespace WAM.WhackAMole.Scores
{
    [Serializable]
    public class HighscoreEntry
    {
        public string PlayerName;

        public int Score;

        public HighscoreEntry(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
}