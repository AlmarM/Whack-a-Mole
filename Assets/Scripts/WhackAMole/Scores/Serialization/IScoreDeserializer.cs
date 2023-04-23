using System.Collections.Generic;

namespace WAM.WhackAMole.Scores.Serialization
{
    /// <summary>
    /// Interface that will provide a way to load high scores from an external source.
    /// </summary>
    public interface IScoreDeserializer
    {
        List<HighscoreEntry> LoadHighscores();
    }
}