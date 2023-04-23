using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Hole;

namespace WAM.WhackAMole.Creatures.Factory
{
    /// <summary>
    /// Interfaces containing required methods for creating new creatures.
    /// </summary>
    public interface ICreatureFactory
    {
        ICreaturePresenter CreateMole();

        ICreatureHolePresenter CreateCreatureHole();

        MoleCreatureConfig CreateMoleConfig();
    }
}