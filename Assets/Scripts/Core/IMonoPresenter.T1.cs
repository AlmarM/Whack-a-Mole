using WAM.Core.Behaviours;

namespace WAM.Core
{
    /// <summary>
    /// Interface for any presenter that controls a MonoBehaviour with a custom view type.
    /// </summary>
    public interface IMonoPresenter<TView> : IMonoPresenter where TView : MonoView
    {
        /// <summary>
        /// Implemented custom view type.
        /// </summary>
        TView View { get; }

        /// <summary>
        /// Assign a custom MonoBehaviour view to this presenter.
        /// </summary>
        /// <param name="view">The custom MonoBehaviour view instance.</param>
        void AssignView(TView view);
    }
}