using UnityEngine;
using WAM.Core.Behaviours;

namespace WAM.WhackAMole.Creatures.Behaviours
{
    /// <summary>
    /// Base class for creature views that are MonoBehaviours with an attached collider. 
    /// </summary>
    public abstract class CreatureBehaviour : MonoView, ICreatureView
    {
        [SerializeField] private CreatureHitbox _hitbox;

        public ICreaturePresenter CreaturePresenter { get; private set; }

        public virtual void PopUp()
        {
        }

        public virtual void Hit()
        {
        }

        public virtual void ResetBack()
        {
        }

        public virtual void Disappear()
        {
        }

        public void SetPresenter(ICreaturePresenter presenter)
        {
            CreaturePresenter = presenter;
        }

        public void EnableHitbox()
        {
            _hitbox.Enable();
        }

        public void DisableHitbox()
        {
            _hitbox.Disable();
        }
    }
}