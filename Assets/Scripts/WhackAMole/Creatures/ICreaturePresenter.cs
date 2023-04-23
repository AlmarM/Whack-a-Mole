using WAM.Core;

namespace WAM.WhackAMole.Creatures
{
    /// <summary>
    /// Interface for any creature presenter that can be interacted with by the game.
    /// </summary>
    public interface ICreaturePresenter : IMonoPresenter
    {
        bool CanPopUp { get; }

        /// <summary>
        /// Called when the creature should pop-up from it's hole.
        /// </summary>
        void PopUp();

        /// <summary>
        /// Called when the player controller interacts with this creature.
        /// </summary>
        void Hit();

        /// <summary>
        /// Called when the creature should reset back to it's default inactive state.
        /// </summary>
        void Reset();

        /// <summary>
        /// Called when the creature needs to move back into it's hole without being hit.
        /// </summary>
        void Disappear();
    }
}