using WAM.Core.DI;
using WAM.Core.Factory;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Behaviours;
using WAM.WhackAMole.Creatures.Hole;
using WAM.WhackAMole.Creatures.Hole.Behaviours;

namespace WAM.WhackAMole.Creatures.Factory
{
    public class CreatureFactory : MonoFactory, ICreatureFactory
    {
        public CreatureFactory(DependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public ICreaturePresenter CreateMole()
        {
            var behaviour = CreateBehaviourFromResources<AnimatedCreatureBehaviour>("Creatures/Mole");
            var moleConfig = dependencyContainer.GetInstance<MoleCreatureConfig>();

            var mole = new MoleCreature(moleConfig);
            mole.AssignView(behaviour);

            behaviour.SetPresenter(mole);

            return mole;
        }

        public ICreatureHolePresenter CreateCreatureHole()
        {
            var behaviour = CreateBehaviourFromResources<CreatureHoleBehaviour>("Game Field/Creature Hole");

            var hole = new CreatureHolePresenter();
            hole.AssignView(behaviour);

            return hole;
        }

        public MoleCreatureConfig CreateMoleConfig()
        {
            return LoadScriptableObjectFromResources<MoleCreatureConfig>("MoleCreatureConfig");
        }
    }
}