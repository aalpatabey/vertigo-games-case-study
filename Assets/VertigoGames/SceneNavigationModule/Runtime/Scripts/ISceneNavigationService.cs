using Cysharp.Threading.Tasks;

namespace VertigoGames.SceneNavigationModule.Runtime.Scripts
{
    public interface ISceneNavigationService
    {
        UniTask<SceneLoadResult> LoadSceneAsync(SceneLoadInfo sceneLoadInfo);
        UniTask<SceneLoadResult> UnloadSceneAsync(SceneUnloadInfo sceneNavigationInfo);
    }
}