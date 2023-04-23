using WAM.Core;
using WAM.WhackAMole.Creatures.Behaviours;

namespace WAM.WhackAMole.Creatures
{
    /// <summary>
    /// Base class for any creature type. Is used to bind to a CreatureBehaviour view.
    /// </summary>
    /// <typeparam name="TView">MonoBehaviour view type.</typeparam>
    public abstract class CreaturePresenter<TView> : MonoPresenter<TView>, ICreaturePresenter
        where TView : CreatureBehaviour
    {
        public bool CanPopUp { get; protected set; }

        public abstract void PopUp();

        public abstract void Hit();

        public abstract void Reset();

        public abstract void Disappear();
    }
}