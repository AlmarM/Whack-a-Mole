using UnityEngine;
using WAM.Core.Behaviours;

namespace WAM.WhackAMole.Creatures.Hole.Behaviours
{
    public class CreatureHoleBehaviour : MonoView
    {
        [SerializeField] private Transform _creatureContainer;

        /// <summary>
        /// Sets the parent of the given creature to this hole.
        /// </summary>
        public void AddCreature(ICreaturePresenter creature)
        {
            creature.Transform.SetParent(_creatureContainer);
        }
    }
}