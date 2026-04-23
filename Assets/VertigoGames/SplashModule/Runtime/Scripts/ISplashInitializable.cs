using Cysharp.Threading.Tasks;

namespace VertigoGames.SplashModule.Runtime.Scripts
{
    public interface ISplashInitializable
    {
        UniTask InitializeAsync(SplashInitializeInfo splashInitializeInfo);
    }
}