using System;
using System.Collections.Generic;

namespace WAM.Core.DI
{
    public class DependencyContainer
    {
        private readonly IDictionary<Type, object> _dependencies;

        public DependencyContainer()
        {
            _dependencies = new Dictionary<Type, object>();
        }

        public void AddDependency<T>(object instance)
        {
            _dependencies.Add(typeof(T), instance);
        }

        public object GetInstance(Type type)
        {
            return _dependencies[type];
        }

        public T GetInstance<T>()
        {
            return (T)GetInstance(typeof(T));
        }

        public T GetInstance<T>(Type type)
        {
            return (T)GetInstance(type);
        }
    }
}