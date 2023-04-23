using WAM.Core;
using WAM.Core.Signals;
using WAM.Core.UI;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Signals;
using WAM.WhackAMole.UI;

namespace WAM.WhackAMole
{
    /// <summary>
    /// The game controller that ties together some gameplay elements and is mainly responsible for changing screens.
    /// </summary>
    public class WhackAMoleController : IUpdatable
    {
        public float RoundTimeLeft { get; private set; } = -1;

        private readonly GameConfig _gameConfig;
        private readonly IGameCanvas _gameCanvas;
        private readonly IScoreHandler _scoreHandler;
        private readonly ISignalHandler _signalHandler;

        public WhackAMoleController(GameConfig gameConfig,
            IGameCanvas gameCanvas,
            IScoreHandler scoreHandler,
            ISignalHandler signalHandler)
        {
            _gameConfig = gameConfig;
            _gameCanvas = gameCanvas;
            _scoreHandler = scoreHandler;
            _signalHandler = signalHandler;

            Initialize();
        }

        public void PlayRound()
        {
            _scoreHandler.Reset();
            _gameCanvas.ShowScreen(GameScreenType.Game);

            RoundTimeLeft = _gameConfig.RoundLength;
        }

        public void StartGame()
        {
            _gameCanvas.ShowScreen(GameScreenType.HighScore);
        }

        public void Update(float deltaTime)
        {
            if (RoundTimeLeft < 0)
            {
                return;
            }

            UpdateRoundTime(deltaTime);
        }

        private void UpdateRoundTime(float deltaTime)
        {
            RoundTimeLeft -= deltaTime;

            if (RoundTimeLeft < 0)
            {
                EndRound();
            }
            else
            {
                _signalHandler.Send(new UpdateRoundTimeSignal
                {
                    Time = RoundTimeLeft
                });
            }
        }

        private void EndRound()
        {
            _gameCanvas.ShowScreen(GameScreenType.Score);

            _signalHandler.Send<EndRoundSignal>();
        }

        private void Initialize()
        {
            _signalHandler.Subscribe<NewRoundSignal>(OnNewRoundSignal);
            _signalHandler.Subscribe<SubmitScoreSignal>(OnSubmitScoreSignal);
        }

        private void OnSubmitScoreSignal(SubmitScoreSignal signal)
        {
            var entry = new HighscoreEntry(signal.PlayerName, signal.Score);

            _scoreHandler.SaveScore(entry);
            _gameCanvas.ShowScreen(GameScreenType.HighScore);
        }

        private void OnNewRoundSignal(NewRoundSignal signal)
        {
            PlayRound();
        }
    }
}