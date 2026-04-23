using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VertigoGames.SceneNavigationModule.Runtime.Scripts
{
    public class UnitySceneNavigationService : ISceneNavigationService
    {
        public async UniTask<SceneLoadResult> LoadSceneAsync(SceneLoadInfo sceneLoadInfo)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync((int)sceneLoadInfo.SceneName, sceneLoadInfo.LoadSceneMode);
            if (loadSceneAsync == null)
            {
                return SceneLoadResult.Fail();
            }
            
            await loadSceneAsync;
            return SceneLoadResult.Success();
        }

        public async UniTask<SceneLoadResult> UnloadSceneAsync(SceneUnloadInfo sceneNavigationInfo)
        {
            AsyncOperation loadSceneAsync = SceneManager.UnloadSceneAsync((int)sceneNavigationInfo.SceneName);
            if (loadSceneAsync == null)
            {
                return SceneLoadResult.Fail();
            }

            await loadSceneAsync;
            return SceneLoadResult.Success();
        }
    }
}