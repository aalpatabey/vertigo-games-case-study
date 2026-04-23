using System;

namespace VertigoGames.ObjectPoolingModule.Runtime.Scripts
{
    public interface IPoolable
    {
        void OnTakeFromPool();
        void OnReturnedToPool();
    }
}