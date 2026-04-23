namespace VertigoGames.ObjectPoolingModule.Runtime.Scripts
{
    public interface IPool<T> where T : IPoolable
    {
        T GetFromPool();
        void ReturnToPool(T poolable);
    }
}