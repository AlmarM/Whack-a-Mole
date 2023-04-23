using WAM.Core.UI;
using WAM.WhackAMole.UI.Behaviours;
using WAM.WhackAMole.UI.Screens;

namespace WAM.WhackAMole.UI.Factory
{
    /// <summary>
    /// Factory providing methods to create game canvas views and instances.
    /// </summary>
    public interface IGameCanvasFactory
    {
        IGameCanvas CreateGameCanvas();

        GameScreenPresenter CreateGameScreen();

        ScoreScreenPresenter CreateScoreScreen();

        HighscoreScreenPresenter CreateHighscoreScreen();

        HighscoreEntryBehaviour CreateHighscoreEntry();
    }
}