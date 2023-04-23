using TMPro;
using UnityEngine;
using WAM.Core.UI.Screens.Behaviours;

namespace WAM.WhackAMole.UI.Screens.Behaviours
{
    public class GameScreenBehaviour : GameCanvasScreenBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _timerText;

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }

        public void SetTime(string time)
        {
            _timerText.text = time;
        }
    }
}