using WAM.Core;

namespace WAM.WhackAMole.Creatures.Hole
{
    /// <summary>
    /// Interface for anything that can take a creature presenter.
    /// </summary>
    public interface ICreatureHolePresenter : IMonoPresenter
    {
        void AddCreature(ICreaturePresenter creature);
    }
}