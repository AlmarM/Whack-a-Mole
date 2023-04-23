namespace WAM.Core.Signals
{
    /// <summary>
    /// Interface that defines methods required for registering and sending signals.
    /// </summary>
    public interface ISignalHandler
    {
        void Subscribe<T>(SignalCallback<T> callback) where T : ISignal;

        void Send<T>() where T : ISignal, new();

        void Send<T>(T signal) where T : ISignal;
    }
}