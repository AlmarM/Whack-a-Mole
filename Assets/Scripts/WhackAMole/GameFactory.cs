using WAM.Core.DI;
using WAM.Core.Factory;
using WAM.Core.Signals;
using WAM.Core.UI;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Scores.Serialization;

namespace WAM.WhackAMole
{
    public class GameFactory : MonoFactory
    {
        public GameFactory(DependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public GameConfig CreateGameConfig()
        {
            return LoadScriptableObjectFromResources<GameConfig>("GameConfig");
        }

        public WhackAMoleController CreateGameController()
        {
            var gameConfig = dependencyContainer.GetInstance<GameConfig>();
            var gameCanvas = dependencyContainer.GetInstance<IGameCanvas>();
            var scoreHandler = dependencyContainer.GetInstance<IScoreHandler>();
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();

            return new WhackAMoleController(gameConfig,
                gameCanvas,
                scoreHandler,
                signalHandler);
        }

        public IScoreHandler CreateScoreHandler()
        {
            var serializer = dependencyContainer.GetInstance<IScoreSerializer>();
            var deserializer = dependencyContainer.GetInstance<IScoreDeserializer>();

            return new ScoreHandler(serializer, deserializer);
        }

        public IScoreSerializer CreateScoreSerializer()
        {
            var deserializer = dependencyContainer.GetInstance<IScoreDeserializer>();

            return new PlayerPrefsSerializer(deserializer);
        }

        public IScoreDeserializer CreateScoreDeserializer()
        {
            return new PlayerPrefsDeserializer();
        }
    }
}