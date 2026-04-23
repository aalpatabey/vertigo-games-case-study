using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace VertigoGames.General.Runtime.Scripts.Factory
{
    public class DefaultPrefabFactory<T> where T : MonoBehaviour
    {
        private readonly IObjectResolver _objectResolver;

        public DefaultPrefabFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public T Instantiate(T prefab, Transform parent = null)
        {
            return _objectResolver.Instantiate(prefab, parent);
        }
    }
}