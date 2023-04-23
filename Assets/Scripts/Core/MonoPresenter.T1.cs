using WAM.Core.Behaviours;

namespace WAM.Core
{
    /// <summary>
    /// Base class for presenters that control a MonoBehaviour.
    /// Contains basic implementation for assigning a view and receiving an Update loop.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public abstract class MonoPresenter<TView> : IMonoPresenter<TView> where TView : MonoView, IView
    {
        public TView View => (TView)MonoView;

        public MonoView MonoView { get; private set; }

        public void AssignView(MonoView view)
        {
            MonoView = view;

            MonoView.UpdateEvent += OnUpdate;

            OnViewAssigned(View);
        }

        public void AssignView(TView view)
        {
            AssignView((MonoView)view);
        }

        protected virtual void OnViewAssigned(TView view)
        {
        }

        protected virtual void OnUpdate(float deltaTime)
        {
        }
    }
}