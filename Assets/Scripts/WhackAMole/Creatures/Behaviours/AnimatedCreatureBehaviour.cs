using System;
using UnityEngine;

namespace WAM.WhackAMole.Creatures.Behaviours
{
    public class AnimatedCreatureBehaviour : CreatureBehaviour
    {
        private static readonly int PopUpAnimationTrigger = Animator.StringToHash("PopUp");
        private static readonly int HitAnimationTrigger = Animator.StringToHash("Hit");
        private static readonly int ResetAnimationTrigger = Animator.StringToHash("Reset");
        private static readonly int DisappearAnimationTrigger = Animator.StringToHash("Disappear");

        [SerializeField] private Animator _animator;

        public event Action ResetAnimationEvent;

        public override void PopUp()
        {
            base.PopUp();

            _animator.SetTrigger(PopUpAnimationTrigger);

            EnableHitbox();
        }

        public override void Hit()
        {
            base.Hit();

            _animator.SetTrigger(HitAnimationTrigger);

            DisableHitbox();
        }

        public override void ResetBack()
        {
            base.ResetBack();

            _animator.SetTrigger(ResetAnimationTrigger);

            _animator.ResetTrigger(PopUpAnimationTrigger);
            _animator.ResetTrigger(HitAnimationTrigger);
            _animator.ResetTrigger(DisappearAnimationTrigger);

            DisableHitbox();
        }

        public override void Disappear()
        {
            base.Disappear();

            _animator.SetTrigger(DisappearAnimationTrigger);
        }

        /// <summary>
        /// String based events triggered via the animator.
        /// </summary>
        /// <param name="eventName">The triggered event.</param>
        public void TriggerAnimationEvent(string eventName)
        {
            switch (eventName)
            {
                case "EnterAnimationReset":
                    ResetAnimationEvent?.Invoke();
                    break;
            }
        }
    }
}