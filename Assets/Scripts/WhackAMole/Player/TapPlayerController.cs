using UnityEngine;
using WAM.Core.Signals;
using WAM.WhackAMole.Creatures;
using WAM.WhackAMole.Player.Inputs;
using WAM.WhackAMole.Scores;
using WAM.WhackAMole.Signals;

namespace WAM.WhackAMole.Player
{
    public class TapPlayerController : IPlayerController
    {
        private static readonly int CreatureLayerMask = LayerMask.GetMask("CreatureHitbox");

        private readonly Camera _camera;

        private readonly IInputStrategy _inputStrategy;
        private readonly IScoreHandler _scoreHandler;
        private readonly ISignalHandler _signalHandler;

        public TapPlayerController(IInputStrategy inputStrategy,
            Camera camera,
            IScoreHandler scoreHandler,
            ISignalHandler signalHandler)
        {
            _inputStrategy = inputStrategy;
            _camera = camera;
            _scoreHandler = scoreHandler;
            _signalHandler = signalHandler;

            Initialize();
        }

        private void Initialize()
        {
            _inputStrategy.ScreenTappedEvent += OnScreenTappedEvent;
        }

        private void OnScreenTappedEvent(Vector2 position)
        {
            if (!TryHitCreature(position, out ICreaturePresenter creature))
            {
                return;
            }

            creature.Hit();
            _scoreHandler.AddPoint();
            _signalHandler.Send<CreatureHitSignal>();
        }

        private bool TryHitCreature(Vector2 position, out ICreaturePresenter creature)
        {
            Ray ray = _camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, CreatureLayerMask))
            {
                var hitbox = hit.collider.GetComponent<CreatureHitbox>();
                if (hitbox != null)
                {
                    creature = hitbox.CreatureView.CreaturePresenter;
                    return true;
                }
            }

            creature = null;
            return false;
        }
    }
}