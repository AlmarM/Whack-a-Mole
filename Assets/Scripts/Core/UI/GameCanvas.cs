using System;
using System.Collections.Generic;
using WAM.Core.UI.Behaviours;

namespace WAM.Core.UI
{
    public class GameCanvas : MonoPresenter<GameCanvasBehaviour>, IGameCanvas
    {
        private readonly IDictionary<Enum, IGameCanvasScreen> _screens;

        public GameCanvas()
        {
            _screens = new Dictionary<Enum, IGameCanvasScreen>();
        }

        public void Show()
        {
            MonoView.gameObject.SetActive(true);
        }

        public void Hide()
        {
            MonoView.gameObject.SetActive(false);
        }

        public void AddScreen(Enum type, IGameCanvasScreen presenter)
        {
            _screens.Add(type, presenter);

            View.AddScreenBehaviour(presenter.MonoView);
        }

        public void ShowScreen(Enum type)
        {
            foreach (IGameCanvasScreen presenter in _screens.Values)
            {
                presenter.Hide();
            }

            _screens[type].Show();

            Show();
        }
    }
}