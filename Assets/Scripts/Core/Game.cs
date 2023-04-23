using System.Collections.Generic;
using WAM.Core.DI;

namespace WAM.Core
{
    /// <summary>
    /// Base class for a new game implementation entry point.
    /// Provides support for setting up dependencies and updatable systems.
    /// </summary>
    public abstract class Game : IUpdatable
    {
        private readonly IList<IUpdatable> _updatableSystems;
        protected readonly DependencyContainer dependencyContainer;

        protected Game()
        {
            _updatableSystems = new List<IUpdatable>();
            dependencyContainer = new DependencyContainer();
        }

        /// <summary>
        /// Updates all cached IUpdatable systems.
        /// </summary>
        /// <param name="deltaTime">The last frame time.</param>
        public virtual void Update(float deltaTime)
        {
            UpdateSystems(deltaTime);
        }

        public void Initialize()
        {
            CreateFactories();
            CreateDependencies();
        }

        /// <summary>
        /// Override to add all factory dependencies.
        /// </summary>
        protected virtual void CreateFactories()
        {
        }

        /// <summary>
        /// Override to add all remaining game dependencies.
        /// </summary>
        protected virtual void CreateDependencies()
        {
        }

        /// <summary>
        /// Add a dependency to be used by factories. Will automatically update IUpdatable systems.
        /// </summary>
        /// <param name="instance">Dependency instance.</param>
        /// <typeparam name="T">Dependency type.</typeparam>
        protected void AddDependency<T>(object instance)
        {
            dependencyContainer.AddDependency<T>(instance);

            if (instance is IUpdatable updatable)
            {
                _updatableSystems.Add(updatable);
            }
        }

        private void UpdateSystems(float deltaTime)
        {
            if (_updatableSystems.Count <= 0)
            {
                return;
            }

            foreach (IUpdatable updatable in _updatableSystems)
            {
                updatable.Update(deltaTime);
            }
        }
    }
}