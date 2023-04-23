using WAM.Core.Behaviours;

namespace WAM.Core.UI.Screens.Behaviours
{
    /// <summary>
    /// Base view class used for creating a separate game screen on the game canvas.
    /// </summary>
    public abstract class GameCanvasScreenBehaviour : MonoView
    {
        /// <summary>
        /// Activates the attached GameObject.
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Deactivates the attached GameObject.
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}