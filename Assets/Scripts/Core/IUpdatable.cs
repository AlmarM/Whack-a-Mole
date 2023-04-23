namespace WAM.Core
{
    /// <summary>
    /// Interface for systems that require an update loop.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Update method called every frame.
        /// </summary>
        /// <param name="deltaTime">The frame time.</param>
        void Update(float deltaTime);
    }
}