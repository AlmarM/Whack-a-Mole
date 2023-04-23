using System.Collections.Generic;
using UnityEngine;
using WAM.Core.Signals;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures;
using WAM.WhackAMole.GameField;
using WAM.WhackAMole.Signals;

namespace WAM.WhackAMole.PopUp
{
    public class RandomPopUpSystem : IPopUpSystem
    {
        private readonly IGameFieldSystem _gameFieldSystem;

        private readonly RandomPopUpConfig _popUpConfig;
        private readonly ISignalHandler _signalHandler;
        private float _nextPopUpTime;

        public RandomPopUpSystem(RandomPopUpConfig config,
            IGameFieldSystem gameFieldSystem,
            ISignalHandler signalHandler)
        {
            _popUpConfig = config;
            _gameFieldSystem = gameFieldSystem;
            _signalHandler = signalHandler;

            Initialize();
        }

        private bool ShouldPopUp => Time.time > _nextPopUpTime;
        public bool Enabled { get; set; }

        public void Update(float deltaTime)
        {
            if (!Enabled)
            {
                return;
            }

            if (!ShouldPopUp)
            {
                return;
            }

            PopUpNextCreature();
            SetNextPopUpTime();
        }

        private void SetNextPopUpTime()
        {
            _nextPopUpTime = Time.time + _popUpConfig.PopUpInterval.GetRandomValue();
        }

        private void PopUpNextCreature()
        {
            IList<ICreaturePresenter> creatures = _gameFieldSystem.Creatures;
            int creaturesCount = creatures.Count;

            for (var i = 0; i < creaturesCount; i++)
            {
                int randomIndex = Random.Range(0, creaturesCount);
                ICreaturePresenter creature = creatures[randomIndex];

                if (!creature.CanPopUp)
                {
                    continue;
                }

                creature.PopUp();

                return;
            }
        }

        private void Initialize()
        {
            _signalHandler.Subscribe<NewRoundSignal>(OnNewRoundSignal);
            _signalHandler.Subscribe<EndRoundSignal>(OnEndRoundSignal);
        }

        private void OnNewRoundSignal(NewRoundSignal signal)
        {
            Enabled = true;
        }

        private void OnEndRoundSignal(EndRoundSignal signal)
        {
            Enabled = false;
        }
    }
}