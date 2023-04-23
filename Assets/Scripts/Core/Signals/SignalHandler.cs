using System;
using System.Collections.Generic;

namespace WAM.Core.Signals
{
    public class SignalHandler : ISignalHandler
    {
        private readonly IDictionary<Type, ISignalSubscription> _subscriptions;

        public SignalHandler()
        {
            _subscriptions = new Dictionary<Type, ISignalSubscription>();
        }

        public void Subscribe<T>(SignalCallback<T> callback) where T : ISignal
        {
            Type signalType = typeof(T);

            if (!_subscriptions.ContainsKey(signalType))
            {
                _subscriptions.Add(signalType, new SignalSubscription<T>());
            }

            var concreteSubscription = (SignalSubscription<T>)_subscriptions[signalType];
            concreteSubscription.Add(callback);
        }

        public void Send<T>() where T : ISignal, new()
        {
            Send(new T());
        }

        public void Send<T>(T signal) where T : ISignal
        {
            if (_subscriptions.TryGetValue(typeof(T), out ISignalSubscription subscription))
            {
                subscription.Invoke(signal);
            }
        }
    }
}