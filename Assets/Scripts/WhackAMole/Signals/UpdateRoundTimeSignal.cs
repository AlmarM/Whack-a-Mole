using WAM.Core.Signals;

namespace WAM.WhackAMole.Signals
{
    public class UpdateRoundTimeSignal : ISignal
    {
        public float Time { get; set; }
    }
}