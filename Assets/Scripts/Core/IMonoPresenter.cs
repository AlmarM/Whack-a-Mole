using UnityEngine;
using WAM.Core.Behaviours;

namespace WAM.Core
{
    /// <summary>
    /// Interface for any presenter that controls a MonoBehaviour.
    /// </summary>
    public interface IMonoPresenter : IPresenter
    {
        /// <summary>
        /// The attached MonoBehaviour.
        /// </summary>
        MonoView MonoView { get; }

        /// <summary>
        /// Shortcut for accessing the Transform component for the attached MonoBehaviour.
        /// </summary>
        Transform Transform => MonoView.transform;

        /// <summary>
        /// Assign a MonoBehaviour to this presenter.
        /// </summary>
        /// <param name="view">The MonoBehaviour instance.</param>
        void AssignView(MonoView view);
    }
}