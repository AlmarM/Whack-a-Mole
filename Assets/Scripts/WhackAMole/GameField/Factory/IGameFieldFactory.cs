using WAM.WhackAMole.Configs;
using WAM.WhackAMole.GameField.Generator;
using WAM.WhackAMole.GameField.Layouts;
using WAM.WhackAMole.PopUp;

namespace WAM.WhackAMole.GameField.Factory
{
    /// <summary>
    /// Interfaces containing required methods for creating new instances related to the game field.
    /// </summary>
    public interface IGameFieldFactory
    {
        IGameFieldSystem CreateGameField();

        GameFieldConfig CreateGameFieldConfig();

        RandomPopUpConfig CreateRandomPopUpConfig();

        IGameFieldGenerator CreateGameFieldGenerator();

        IFieldLayoutGenerator CreateFieldLayoutGenerator();

        IPopUpSystem CreatePopUpSystem();
    }
}