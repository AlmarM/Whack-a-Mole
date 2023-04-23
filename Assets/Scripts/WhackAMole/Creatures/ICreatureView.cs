using WAM.Core;

namespace WAM.WhackAMole.Creatures
{
    /// <summary>
    /// Interface that provides methods used by the creature presenter to control the view.
    /// </summary>
    public interface ICreatureView : IView
    {
        /// <summary>
        /// Show the pop-up visual state.
        /// </summary>
        void PopUp();

        /// <summary>
        /// Show the hit visual state.
        /// </summary>
        void Hit();

        /// <summary>
        /// Reset back to a default visual state.
        /// </summary>
        void ResetBack();

        /// <summary>
        /// Show the disappear visual state.
        /// </summary>
        void Disappear();
    }
}