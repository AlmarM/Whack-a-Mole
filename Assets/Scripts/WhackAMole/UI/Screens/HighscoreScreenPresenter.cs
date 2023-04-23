using System.Collections.Generic;
using WAM.Core.Signals;
using WAM.Core.UI.Screens;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Scores.Serialization;
using WAM.WhackAMole.Signals;
using WAM.WhackAMole.UI.Behaviours;
using WAM.WhackAMole.UI.Factory;
using WAM.WhackAMole.UI.Screens.Behaviours;

namespace WAM.WhackAMole.UI.Screens
{
    public class HighscoreScreenPresenter : GameCanvasScreen<HighscoreScreenBehaviour>
    {
        private readonly IGameCanvasFactory _canvasFactory;
        private readonly IScoreDeserializer _scoreDeserializer;
        private readonly ISignalHandler _signalHandler;

        public HighscoreScreenPresenter(IGameCanvasFactory canvasFactory,
            IScoreDeserializer scoreDeserializer,
            ISignalHandler signalHandler)
        {
            _canvasFactory = canvasFactory;
            _scoreDeserializer = scoreDeserializer;
            _signalHandler = signalHandler;
        }

        public override void Show()
        {
            SetHighscores(_scoreDeserializer.LoadHighscores());

            base.Show();
        }

        public void ClearHighscores()
        {
            View.DestroyHighscoreObjects();
        }

        protected override void OnViewAssigned(HighscoreScreenBehaviour view)
        {
            base.OnViewAssigned(view);

            view.PlayButtonClickedEvent += OnPlayButtonClickedEvent;
        }

        private void SetHighscores(IList<HighscoreEntry> highscores)
        {
            foreach (HighscoreEntry entry in highscores)
            {
                HighscoreEntryBehaviour entryBehaviour = _canvasFactory.CreateHighscoreEntry();
                entryBehaviour.SetData(entry);

                View.AddHighscoreEntry(entryBehaviour);
            }
        }

        private void OnPlayButtonClickedEvent()
        {
            ClearHighscores();

            _signalHandler.Send<NewRoundSignal>();
        }
    }
}