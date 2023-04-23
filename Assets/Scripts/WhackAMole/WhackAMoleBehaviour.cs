using UnityEngine;

namespace WAM.WhackAMole
{
    /// <summary>
    /// Entry point for the game through hooks supplied by the MonoBehaviour.
    /// </summary>
    public class WhackAMoleBehaviour : MonoBehaviour
    {
        private WhackAMoleGame _game;

        private void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _game = new WhackAMoleGame();
            _game.Initialize();
            _game.Run();
        }

        private void Update()
        {
            _game.Update(Time.deltaTime);
        }
    }
}