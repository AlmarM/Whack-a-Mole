using System;
using WAM.Core.DI;
using WAM.Core.Factory;
using WAM.Core.Signals;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Factory;
using WAM.WhackAMole.GameField.Behaviours;
using WAM.WhackAMole.GameField.Generator;
using WAM.WhackAMole.GameField.Layouts;
using WAM.WhackAMole.PopUp;

namespace WAM.WhackAMole.GameField.Factory
{
    public class GameFieldFactory : MonoFactory, IGameFieldFactory
    {
        public GameFieldFactory(DependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public IGameFieldSystem CreateGameField()
        {
            var behaviour = CreateBehaviourFromResources<GameFieldBehaviour>("Game Field/Game Field");
            var gameFieldConfig = dependencyContainer.GetInstance<GameFieldConfig>();
            var fieldGenerator = dependencyContainer.GetInstance<IGameFieldGenerator>();
            var creatureFactory = dependencyContainer.GetInstance<ICreatureFactory>();
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();

            var gameField = new GameFieldSystem(gameFieldConfig, fieldGenerator, creatureFactory, signalHandler);
            gameField.AssignView(behaviour);

            return gameField;
        }

        public GameFieldConfig CreateGameFieldConfig()
        {
            return LoadScriptableObjectFromResources<GameFieldConfig>("GameFieldConfig");
        }

        public RandomPopUpConfig CreateRandomPopUpConfig()
        {
            return LoadScriptableObjectFromResources<RandomPopUpConfig>("RandomPopUpConfig");
        }

        public IGameFieldGenerator CreateGameFieldGenerator()
        {
            var creatureFactory = dependencyContainer.GetInstance<ICreatureFactory>();
            var gameFieldConfig = dependencyContainer.GetInstance<GameFieldConfig>();
            IFieldLayoutGenerator layoutGenerator = CreateFieldLayoutGenerator();

            return new GameFieldGenerator(gameFieldConfig, creatureFactory, layoutGenerator);
        }

        public IFieldLayoutGenerator CreateFieldLayoutGenerator()
        {
            var gameFieldConfig = dependencyContainer.GetInstance<GameFieldConfig>();

            return gameFieldConfig.FieldLayoutType switch
            {
                FieldLayoutType.Grid => new GridLayoutGenerator(),
                FieldLayoutType.ZigZag => new ZigzagLayoutGenerator(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public IPopUpSystem CreatePopUpSystem()
        {
            var gameFieldConfig = dependencyContainer.GetInstance<GameFieldConfig>();
            var randomPopUpConfig = dependencyContainer.GetInstance<RandomPopUpConfig>();
            var gameFieldSystem = dependencyContainer.GetInstance<IGameFieldSystem>();
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();

            return gameFieldConfig.PopUpType switch
            {
                PopUpType.Random => new RandomPopUpSystem(randomPopUpConfig, gameFieldSystem, signalHandler),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}