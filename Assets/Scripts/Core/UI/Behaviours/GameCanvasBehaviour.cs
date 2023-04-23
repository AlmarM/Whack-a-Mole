using WAM.Core.Behaviours;

namespace WAM.Core.UI.Behaviours
{
    public class GameCanvasBehaviour : MonoView
    {
        public void AddScreenBehaviour(MonoView screen)
        {
            screen.transform.SetParent(transform, false);
        }
    }
}