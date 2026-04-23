using System;
using System.Collections.Generic;

namespace VertigoGames.ObjectPoolingModule.Runtime.Scripts
{
    public class StackPool<T> : IPool<T> where T : IPoolable
    {
        private readonly Stack<T> _poolables = new Stack<T>();
        
        private readonly Func<T> _factory;

        public StackPool(Func<T> factory)
        {
            _factory = factory;
        }

        public T GetFromPool()
        {
            T poolable = _poolables.Count > 0 ? _poolables.Pop() : _factory.Invoke();

            poolable.OnTakeFromPool();
            
            return poolable;
        }

        public void ReturnToPool(T poolable)
        {
            if (!_poolables.Contains(poolable))
            {
                poolable.OnReturnedToPool();
                _poolables.Push(poolable);
            }
        }
    }
}