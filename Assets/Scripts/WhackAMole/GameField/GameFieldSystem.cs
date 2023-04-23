using System.Collections.Generic;
using WAM.Core;
using WAM.Core.Signals;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures;
using WAM.WhackAMole.Creatures.Factory;
using WAM.WhackAMole.Creatures.Hole;
using WAM.WhackAMole.GameField.Behaviours;
using WAM.WhackAMole.GameField.Generator;
using WAM.WhackAMole.Signals;

namespace WAM.WhackAMole.GameField
{
    public class GameFieldSystem : MonoPresenter<GameFieldBehaviour>, IGameFieldSystem
    {
        public IList<ICreatureHolePresenter> Holes { get; private set; }

        public IList<ICreaturePresenter> Creatures { get; private set; }

        private readonly GameFieldConfig _gameFieldConfig;
        private readonly IGameFieldGenerator _fieldGenerator;
        private readonly ICreatureFactory _creatureFactory;
        private readonly ISignalHandler _signalHandler;

        public GameFieldSystem(GameFieldConfig gameFieldConfig,
            IGameFieldGenerator fieldGenerator,
            ICreatureFactory creatureFactory,
            ISignalHandler signalHandler)
        {
            _gameFieldConfig = gameFieldConfig;
            _fieldGenerator = fieldGenerator;
            _creatureFactory = creatureFactory;
            _signalHandler = signalHandler;

            Initialize();
        }

        public void Generate()
        {
            GenerateHoles();
            CreateCreatures();
        }

        private void GenerateHoles()
        {
            Holes = _fieldGenerator.CreateHoles();

            View.PlaceHoles(Holes, _gameFieldConfig);
        }

        private void CreateCreatures()
        {
            foreach (ICreatureHolePresenter hole in Holes)
            {
                ICreaturePresenter mole = _creatureFactory.CreateMole();
                mole.Reset();

                hole.AddCreature(mole);

                Creatures.Add(mole);
            }
        }

        private void Initialize()
        {
            Creatures = new List<ICreaturePresenter>();

            _signalHandler.Subscribe<EndRoundSignal>(OnEndRoundSignal);
        }

        private void OnEndRoundSignal(EndRoundSignal signal)
        {
            DisappearAllCreature();
        }

        private void DisappearAllCreature()
        {
            foreach (ICreaturePresenter creature in Creatures)
            {
                creature.Disappear();
            }
        }
    }
}