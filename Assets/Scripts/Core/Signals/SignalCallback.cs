namespace WAM.Core.Signals
{
    /// <summary>
    /// A callback that's invoked when a specific signal is send.
    /// </summary>
    public delegate void SignalCallback<in T>(T signal) where T : ISignal;
}