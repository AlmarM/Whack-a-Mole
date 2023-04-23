using WAM.Core;
using WAM.Core.Signals;
using WAM.Core.UI;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Factory;
using WAM.WhackAMole.GameField;
using WAM.WhackAMole.GameField.Factory;
using WAM.WhackAMole.GameField.Generator;
using WAM.WhackAMole.Player;
using WAM.WhackAMole.Player.Factory;
using WAM.WhackAMole.Player.Inputs;
using WAM.WhackAMole.PopUp;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Scores.Serialization;
using WAM.WhackAMole.UI;
using WAM.WhackAMole.UI.Factory;
using WAM.WhackAMole.UI.Screens;

namespace WAM.WhackAMole
{
    /// <summary>
    /// Game instance for setting up dependencies.
    /// </summary>
    public class WhackAMoleGame : Game
    {
        private WhackAMoleController _gameController;

        public void Run()
        {
            CreateGame();

            _gameController = dependencyContainer.GetInstance<WhackAMoleController>();
            _gameController.StartGame();
        }

        protected override void CreateFactories()
        {
            AddDependency<IGameFieldFactory>(new GameFieldFactory(dependencyContainer));
            AddDependency<ICreatureFactory>(new CreatureFactory(dependencyContainer));
            AddDependency<IPlayerFactory>(new PlayerFactory(dependencyContainer));
            AddDependency<IGameCanvasFactory>(new GameCanvasFactory(dependencyContainer));
            AddDependency<GameFactory>(new GameFactory(dependencyContainer));
        }

        protected override void CreateDependencies()
        {
            CreateConfigDependencies();
            CreateSignalDependencies();
            CreateGameFieldDependencies();
            CreatePopUpDependencies();
            CreateScoreDependencies();
            CreateCanvasDependencies();
            CreateGameDependencies();
            CreateInputDependencies();
        }

        private void CreateConfigDependencies()
        {
            var gameFieldFactory = dependencyContainer.GetInstance<IGameFieldFactory>();
            var creatureFactory = dependencyContainer.GetInstance<ICreatureFactory>();
            var gameFactory = dependencyContainer.GetInstance<GameFactory>();

            AddDependency<GameFieldConfig>(gameFieldFactory.CreateGameFieldConfig());
            AddDependency<RandomPopUpConfig>(gameFieldFactory.CreateRandomPopUpConfig());
            AddDependency<MoleCreatureConfig>(creatureFactory.CreateMoleConfig());
            AddDependency<GameConfig>(gameFactory.CreateGameConfig());
        }

        private void CreateSignalDependencies()
        {
            AddDependency<ISignalHandler>(new SignalHandler());
        }

        private void CreateGameFieldDependencies()
        {
            var gameFieldFactory = dependencyContainer.GetInstance<IGameFieldFactory>();

            AddDependency<IGameFieldGenerator>(gameFieldFactory.CreateGameFieldGenerator());
            AddDependency<IGameFieldSystem>(gameFieldFactory.CreateGameField());
        }

        private void CreatePopUpDependencies()
        {
            var gameFieldFactory = dependencyContainer.GetInstance<IGameFieldFactory>();

            AddDependency<IPopUpSystem>(gameFieldFactory.CreatePopUpSystem());
        }

        private void CreateInputDependencies()
        {
            var playerFactory = dependencyContainer.GetInstance<IPlayerFactory>();

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            AddDependency<IInputStrategy>(new WindowsInputStrategy());
#elif UNITY_ANDROID
            AddDependency<IInputStrategy>(new AndroidInputStrategy());
#endif

            AddDependency<IPlayerController>(playerFactory.CreatePlayerController());
        }

        private void CreateCanvasDependencies()
        {
            var canvasFactory = dependencyContainer.GetInstance<IGameCanvasFactory>();

            AddDependency<IGameCanvas>(canvasFactory.CreateGameCanvas());
            AddDependency<GameScreenPresenter>(canvasFactory.CreateGameScreen());
            AddDependency<ScoreScreenPresenter>(canvasFactory.CreateScoreScreen());
            AddDependency<HighscoreScreenPresenter>(canvasFactory.CreateHighscoreScreen());
        }

        private void CreateGameDependencies()
        {
            var gameFactory = dependencyContainer.GetInstance<GameFactory>();

            AddDependency<WhackAMoleController>(gameFactory.CreateGameController());
        }

        private void CreateScoreDependencies()
        {
            var gameFactory = dependencyContainer.GetInstance<GameFactory>();

            AddDependency<IScoreDeserializer>(gameFactory.CreateScoreDeserializer());
            AddDependency<IScoreSerializer>(gameFactory.CreateScoreSerializer());
            AddDependency<IScoreHandler>(gameFactory.CreateScoreHandler());
        }

        private void CreateGame()
        {
            var gameFieldSystem = dependencyContainer.GetInstance<IGameFieldSystem>();
            gameFieldSystem.Generate();

            CreateGameScreens();
        }

        private void CreateGameScreens()
        {
            var gameCanvas = dependencyContainer.GetInstance<IGameCanvas>();

            gameCanvas.AddScreen(GameScreenType.Game, dependencyContainer.GetInstance<GameScreenPresenter>());
            gameCanvas.AddScreen(GameScreenType.Score, dependencyContainer.GetInstance<ScoreScreenPresenter>());
            gameCanvas.AddScreen(GameScreenType.HighScore, dependencyContainer.GetInstance<HighscoreScreenPresenter>());
        }
    }
}