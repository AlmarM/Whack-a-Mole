using WAM.Core.DI;
using WAM.Core.Factory;
using WAM.Core.Signals;
using WAM.Core.UI;
using WAM.Core.UI.Behaviours;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Scores.Serialization;
using WAM.WhackAMole.UI.Behaviours;
using WAM.WhackAMole.UI.Screens;
using WAM.WhackAMole.UI.Screens.Behaviours;

namespace WAM.WhackAMole.UI.Factory
{
    public class GameCanvasFactory : MonoFactory, IGameCanvasFactory
    {
        public GameCanvasFactory(DependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public IGameCanvas CreateGameCanvas()
        {
            var behaviour = CreateBehaviourFromResources<GameCanvasBehaviour>("UI/Game Canvas");

            var gameCanvas = new GameCanvas();
            gameCanvas.AssignView(behaviour);

            return gameCanvas;
        }

        public GameScreenPresenter CreateGameScreen()
        {
            var behaviour = CreateBehaviourFromResources<GameScreenBehaviour>("UI/Screens/Game Screen");
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();
            var scoreHandler = dependencyContainer.GetInstance<IScoreHandler>();

            var gameScreen = new GameScreenPresenter(signalHandler, scoreHandler);
            gameScreen.AssignView(behaviour);

            return gameScreen;
        }

        public ScoreScreenPresenter CreateScoreScreen()
        {
            var behaviour = CreateBehaviourFromResources<ScoreScreenBehaviour>("UI/Screens/Score Screen");
            var scoreHandler = dependencyContainer.GetInstance<IScoreHandler>();
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();

            var scoreScreen = new ScoreScreenPresenter(scoreHandler, signalHandler);
            scoreScreen.AssignView(behaviour);

            return scoreScreen;
        }

        public HighscoreScreenPresenter CreateHighscoreScreen()
        {
            var behaviour = CreateBehaviourFromResources<HighscoreScreenBehaviour>("UI/Screens/Highscore Screen");
            var canvasFactory = dependencyContainer.GetInstance<IGameCanvasFactory>();
            var scoreDeserializer = dependencyContainer.GetInstance<IScoreDeserializer>();
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();

            var highscoreScreen = new HighscoreScreenPresenter(canvasFactory, scoreDeserializer, signalHandler);
            highscoreScreen.AssignView(behaviour);

            return highscoreScreen;
        }

        public HighscoreEntryBehaviour CreateHighscoreEntry()
        {
            return CreateBehaviourFromResources<HighscoreEntryBehaviour>("UI/Highscore Entry");
        }
    }
}