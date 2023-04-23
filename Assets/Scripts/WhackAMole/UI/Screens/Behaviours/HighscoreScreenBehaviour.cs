using System;
using UnityEngine;
using UnityEngine.UI;
using WAM.Core.UI.Screens.Behaviours;
using WAM.WhackAMole.UI.Behaviours;

namespace WAM.WhackAMole.UI.Screens.Behaviours
{
    public class HighscoreScreenBehaviour : GameCanvasScreenBehaviour
    {
        [SerializeField] private Transform _entryContainer;
        [SerializeField] private Button _playButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClickedEvent);
        }

        public event Action PlayButtonClickedEvent;

        public void DestroyHighscoreObjects()
        {
            foreach (Transform child in _entryContainer)
            {
                Destroy(child.gameObject);
            }
        }

        public void AddHighscoreEntry(HighscoreEntryBehaviour behaviour)
        {
            behaviour.transform.SetParent(_entryContainer, false);
        }

        private void OnPlayButtonClickedEvent()
        {
            PlayButtonClickedEvent?.Invoke();
        }
    }
}