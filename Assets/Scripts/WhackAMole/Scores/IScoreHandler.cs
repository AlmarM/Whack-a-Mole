namespace WAM.WhackAMole.Scores
{
    /// <summary>
    /// Interface for handling highscores.
    /// </summary>
    public interface IScoreHandler
    {
        int Score { get; }

        void AddPoint();

        void Reset();

        void SaveScore(HighscoreEntry entry);
    }
}