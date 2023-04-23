using WAM.Core.Signals;

namespace WAM.WhackAMole.Signals
{
    public class SubmitScoreSignal : ISignal
    {
        public string PlayerName { get; set; }

        public int Score { get; set; }
    }
}