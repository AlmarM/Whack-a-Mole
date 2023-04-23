using System.Collections.Generic;
using WAM.WhackAMole.Creatures.Hole;

namespace WAM.WhackAMole.GameField.Generator
{
    /// <summary>
    /// Interfaces containing required methods used by the game field to setup a game field.
    /// </summary>
    public interface IGameFieldGenerator
    {
        IList<ICreatureHolePresenter> CreateHoles();
    }
}