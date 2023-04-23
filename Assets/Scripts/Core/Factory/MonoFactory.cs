using UnityEngine;
using WAM.Core.Behaviours;
using WAM.Core.DI;

namespace WAM.Core.Factory
{
    /// <summary>
    /// Base factory providing methods to load assets from Resources folders.
    /// </summary>
    public class MonoFactory
    {
        private const string PrefabPathPrefix = "Prefabs/";
        private const string ScriptableObjectPathPrefix = "Scriptable Objects/";

        protected readonly DependencyContainer dependencyContainer;

        public MonoFactory(DependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public T LoadFromResources<T>(string path) where T : Object
        {
            return (T)Resources.Load(path);
        }

        public ScriptableObject LoadScriptableObjectFromResources(string objectPath)
        {
            var path = $"{ScriptableObjectPathPrefix}{objectPath}";
            return LoadFromResources<ScriptableObject>(path);
        }

        public T LoadScriptableObjectFromResources<T>(string objectPath) where T : ScriptableObject
        {
            return (T)LoadScriptableObjectFromResources(objectPath);
        }

        public GameObject CreateGameObjectFromInstance(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }

        public GameObject CreateGameObjectFromResources(string objectPath)
        {
            var path = $"{PrefabPathPrefix}{objectPath}";
            var gameObject = LoadFromResources<GameObject>(path);

            return CreateGameObjectFromInstance(gameObject);
        }

        public T CreateBehaviourFromResources<T>(string objectPath) where T : MonoView
        {
            return CreateGameObjectFromResources(objectPath).GetComponent<T>();
        }
    }
}