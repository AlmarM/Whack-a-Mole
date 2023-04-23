using WAM.Core.UI.Screens.Behaviours;

namespace WAM.Core.UI.Screens
{
    /// <summary>
    /// Base presenter class for creating a separate game screen to be used by the game canvas.
    /// </summary>
    public abstract class GameCanvasScreen<TView> : MonoPresenter<TView>, IGameCanvasScreen
        where TView : GameCanvasScreenBehaviour
    {
        public virtual void Show()
        {
            View.Show();
        }

        public virtual void Hide()
        {
            View.Hide();
        }
    }
}