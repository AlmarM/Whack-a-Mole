namespace WAM.WhackAMole.Scores.Serialization
{
    /// <summary>
    /// Interface that will provide a way to save high scores to an external source.
    /// </summary>
    public interface IScoreSerializer
    {
        void SaveScore(HighscoreEntry entry);
    }
}