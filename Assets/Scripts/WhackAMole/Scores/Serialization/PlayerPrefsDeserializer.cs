using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WAM.WhackAMole.Scores.Serialization
{
    public class PlayerPrefsDeserializer : IScoreDeserializer
    {
        public List<HighscoreEntry> LoadHighscores()
        {
            string prefsKey = PlayerPrefsSerializer.PlayerPrefsHighscoreKey;

            if (!PlayerPrefs.HasKey(prefsKey))
            {
                return new List<HighscoreEntry>();
            }

            var json = PlayerPrefs.GetString(prefsKey);
            List<HighscoreEntry> highscoreEntries = JsonUtility.FromJson<ScoreDto>(json).Highscores;

            highscoreEntries = highscoreEntries
                .OrderByDescending(entry => entry.Score)
                .ToList();

            return highscoreEntries;
        }
    }
}