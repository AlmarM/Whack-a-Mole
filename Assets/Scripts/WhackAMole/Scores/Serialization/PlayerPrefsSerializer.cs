using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WAM.WhackAMole.Scores.Serialization
{
    public class PlayerPrefsSerializer : IScoreSerializer
    {
        public const string PlayerPrefsHighscoreKey = "highscores";

        private readonly IScoreDeserializer _scoreDeserializer;

        public PlayerPrefsSerializer(IScoreDeserializer scoreDeserializer)
        {
            _scoreDeserializer = scoreDeserializer;
        }

        public void SaveScore(HighscoreEntry entry)
        {
            List<HighscoreEntry> entries = _scoreDeserializer.LoadHighscores();
            entries.Add(entry);

            entries = entries
                .OrderByDescending(highscoreEntry => highscoreEntry.Score)
                .ToList();

            string json = JsonUtility.ToJson(new ScoreDto
            {
                Highscores = entries
            });

            PlayerPrefs.SetString(PlayerPrefsHighscoreKey, json);
        }
    }
}