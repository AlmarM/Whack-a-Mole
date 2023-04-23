using System;

namespace WAM.Core.UI
{
    /// <summary>
    /// Interface for implementing a screen-flow system that supports showing and hiding game screens.
    /// </summary>
    public interface IGameCanvas
    {
        /// <summary>
        /// Enables the game canvas.
        /// </summary>
        void Show();

        /// <summary>
        /// Disables the game canvas.
        /// </summary>
        void Hide();

        /// <summary>
        /// Add a game screen to this canvas.
        /// </summary>
        /// <param name="type">Custom Enum type to unique identify this screen.</param>
        /// <param name="presenter">The game screen presenter.</param>
        void AddScreen(Enum type, IGameCanvasScreen presenter);

        /// <summary>
        /// Show a previously added game screen.
        /// </summary>
        /// <param name="type">Enum type to identify what game screen to show.</param>
        void ShowScreen(Enum type);
    }
}