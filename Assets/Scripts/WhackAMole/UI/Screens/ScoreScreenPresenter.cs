using WAM.Core.Signals;
using WAM.Core.UI.Screens;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Signals;
using WAM.WhackAMole.UI.Screens.Behaviours;

namespace WAM.WhackAMole.UI.Screens
{
    public class ScoreScreenPresenter : GameCanvasScreen<ScoreScreenBehaviour>
    {
        private readonly IScoreHandler _scoreHandler;
        private readonly ISignalHandler _signalHandler;

        public ScoreScreenPresenter(IScoreHandler scoreHandler, ISignalHandler signalHandler)
        {
            _scoreHandler = scoreHandler;
            _signalHandler = signalHandler;
        }

        public override void Show()
        {
            base.Show();

            View.SetScore(_scoreHandler.Score);
        }

        protected override void OnViewAssigned(ScoreScreenBehaviour view)
        {
            base.OnViewAssigned(view);

            View.SubmitButtonClickedEvent += OnSubmitButtonClicked;
        }

        private void OnSubmitButtonClicked(string playerName)
        {
            View.ResetNameInput();

            _signalHandler.Send(new SubmitScoreSignal
            {
                PlayerName = playerName,
                Score = _scoreHandler.Score
            });
        }
    }
}