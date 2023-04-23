using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WAM.Core.UI.Screens.Behaviours;

namespace WAM.WhackAMole.UI.Screens.Behaviours
{
    public class ScoreScreenBehaviour : GameCanvasScreenBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private Button _submitButton;

        private void Awake()
        {
            _submitButton.onClick.AddListener(OnSubmitClicked);
        }

        public event Action<string> SubmitButtonClickedEvent;

        public void ResetNameInput()
        {
            _nameInput.text = string.Empty;
        }

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void OnSubmitClicked()
        {
            SubmitButtonClickedEvent?.Invoke(_nameInput.text);
        }
    }
}