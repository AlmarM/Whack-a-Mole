namespace WAM.Core.UI
{
    /// <summary>
    /// Interface for presenters that control a game screen to be used with the game canvas.
    /// </summary>
    public interface IGameCanvasScreen : IMonoPresenter
    {
        void Show();

        void Hide();
    }
}