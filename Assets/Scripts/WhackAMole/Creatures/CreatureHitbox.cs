using UnityEngine;
using WAM.WhackAMole.Creatures.Behaviours;

namespace WAM.WhackAMole.Creatures
{
    public class CreatureHitbox : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private CreatureBehaviour _attachedView;

        /// <summary>
        /// Attached view to connect back to the creature that uses this hitbox.
        /// </summary>
        public CreatureBehaviour CreatureView => _attachedView;

        public void Enable()
        {
            _collider.enabled = true;
        }

        public void Disable()
        {
            _collider.enabled = false;
        }
    }
}