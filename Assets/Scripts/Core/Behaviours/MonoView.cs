using System;
using UnityEngine;

namespace WAM.Core.Behaviours
{
    /// <summary>
    /// Base class for views that control a MonoBehaviour.
    /// </summary>
    public abstract class MonoView : MonoBehaviour, IView
    {
        protected virtual void Update()
        {
            UpdateEvent?.Invoke(Time.deltaTime);
        }

        /// <summary>
        /// Fired every time a MonoBehaviour is updated.
        /// </summary>
        public event Action<float> UpdateEvent;
    }
}