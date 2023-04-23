using System.Collections.Generic;
using WAM.WhackAMole.Creatures;

namespace WAM.WhackAMole.GameField
{
    public interface IGameFieldSystem
    {
        IList<ICreaturePresenter> Creatures { get; }

        void Generate();
    }
}