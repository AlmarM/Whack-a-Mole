using UnityEngine;
using WAM.Core.DI;
using WAM.Core.Factory;
using WAM.Core.Signals;
using WAM.WhackAMole.Player.Inputs;
using WAM.WhackAMole.Scores;

namespace WAM.WhackAMole.Player.Factory
{
    public class PlayerFactory : MonoFactory, IPlayerFactory
    {
        public PlayerFactory(DependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public IPlayerController CreatePlayerController()
        {
            var inputStrategy = dependencyContainer.GetInstance<IInputStrategy>();
            var scoreHandler = dependencyContainer.GetInstance<IScoreHandler>();
            var signalHandler = dependencyContainer.GetInstance<ISignalHandler>();

            return new TapPlayerController(inputStrategy, Camera.main, scoreHandler, signalHandler);
        }
    }
}