using WAM.Core.Signals;
using WAM.Core.UI.Screens;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Signals;
using WAM.WhackAMole.UI.Screens.Behaviours;

namespace WAM.WhackAMole.UI.Screens
{
    public class GameScreenPresenter : GameCanvasScreen<GameScreenBehaviour>
    {
        private const string TimeFormat = "{0:0}";

        private readonly ISignalHandler _signalHandler;
        private readonly IScoreHandler _scoreHandler;

        public GameScreenPresenter(ISignalHandler signalHandler, IScoreHandler scoreHandler)
        {
            _signalHandler = signalHandler;
            _scoreHandler = scoreHandler;

            Initialize();
        }

        public void SetTime(float time)
        {
            View.SetTime(string.Format(TimeFormat, time));
        }

        public void SetScore(int score)
        {
            View.SetScore(score);
        }

        private void Initialize()
        {
            _signalHandler.Subscribe<NewRoundSignal>(OnNewRoundSignal);
            _signalHandler.Subscribe<CreatureHitSignal>(OnCreatureHitSignal);
            _signalHandler.Subscribe<UpdateRoundTimeSignal>(OnUpdateRoundTimeSignal);
        }

        private void OnUpdateRoundTimeSignal(UpdateRoundTimeSignal signal)
        {
            SetTime(signal.Time);
        }

        private void OnNewRoundSignal(NewRoundSignal signal)
        {
            SetScore(0);
        }

        private void OnCreatureHitSignal(CreatureHitSignal signal)
        {
            SetScore(_scoreHandler.Score);
        }
    }
}