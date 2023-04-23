using WAM.Core;
using WAM.WhackAMole.Creatures.Hole.Behaviours;

namespace WAM.WhackAMole.Creatures.Hole
{
    public class CreatureHolePresenter : MonoPresenter<CreatureHoleBehaviour>, ICreatureHolePresenter
    {
        public void AddCreature(ICreaturePresenter creature)
        {
            View.AddCreature(creature);
        }
    }
}