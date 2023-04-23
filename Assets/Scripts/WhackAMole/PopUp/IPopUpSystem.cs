using WAM.Core;

namespace WAM.WhackAMole.PopUp
{
    /// <summary>
    /// Interface used by systems that will control what creature will pop-up from a hole.
    /// </summary>
    public interface IPopUpSystem : IUpdatable
    {
        bool Enabled { get; set; }
    }
}