using UnityEngine;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Behaviours;

namespace WAM.WhackAMole.Creatures
{
    public class MoleCreature : CreaturePresenter<AnimatedCreatureBehaviour>
    {
        private readonly MoleCreatureConfig _moleConfig;
        private float _disappearTime;
        private bool _isUp;

        public MoleCreature(MoleCreatureConfig moleConfig)
        {
            _moleConfig = moleConfig;
        }

        public override void PopUp()
        {
            View.PopUp();

            CanPopUp = false;
            _isUp = true;

            _disappearTime = Time.time + _moleConfig.DisappearInterval.GetRandomValue();
        }

        public override void Hit()
        {
            View.Hit();

            _isUp = false;
        }

        public override void Reset()
        {
            CanPopUp = true;

            View.ResetBack();
        }

        public override void Disappear()
        {
            View.Disappear();

            _isUp = false;
        }

        protected override void OnViewAssigned(AnimatedCreatureBehaviour view)
        {
            base.OnViewAssigned(view);

            view.ResetAnimationEvent += OnResetAnimationEvent;
        }

        private void OnResetAnimationEvent()
        {
            Reset();
        }

        protected override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);

            if (!_isUp)
            {
                return;
            }

            if (Time.time < _disappearTime)
            {
                return;
            }

            Disappear();
        }
    }
}