namespace WAM.Core.Signals
{
    /// <summary>
    /// Interface that represents a list of subscriptions.
    /// </summary>
    public interface ISignalSubscription
    {
        void Invoke(ISignal signal);
    }
}