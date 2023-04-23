using System.Collections.Generic;

namespace WAM.Core.Signals
{
    public class SignalSubscription<TSignal> : ISignalSubscription where TSignal : ISignal
    {
        private readonly IList<SignalCallback<TSignal>> _listeners;

        public SignalSubscription()
        {
            _listeners = new List<SignalCallback<TSignal>>();
        }

        public void Invoke(ISignal signal)
        {
            foreach (SignalCallback<TSignal> listener in _listeners)
            {
                listener.Invoke((TSignal)signal);
            }
        }

        public void Add(SignalCallback<TSignal> callback)
        {
            _listeners.Add(callback);
        }
    }
}