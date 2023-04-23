using TMPro;
using UnityEngine;
using WAM.Core.Behaviours;
using WAM.WhackAMole.Scores;

namespace WAM.WhackAMole.UI.Behaviours
{
    public class HighscoreEntryBehaviour : MonoView
    {
        [SerializeField] private TMP_Text _playerNameText;
        [SerializeField] private TMP_Text _scoreText;

        public void SetData(HighscoreEntry entry)
        {
            _playerNameText.text = entry.PlayerName;
            _scoreText.text = entry.Score.ToString();
        }
    }
}