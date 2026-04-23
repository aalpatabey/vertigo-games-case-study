using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace VertigoGames.SceneNavigationModule.Runtime.Scripts
{
    public class SceneNavigationController
    {
        private readonly ISceneNavigationService _sceneNavigationService;

        private readonly List<SceneInfo> _activeScenes = new List<SceneInfo>();

        public SceneNavigationController(ISceneNavigationService sceneNavigationService)
        {
            _sceneNavigationService = sceneNavigationService;
            
            _activeScenes.Add(new SceneInfo(0));
        }
        
        public async UniTask<SceneLoadResult> LoadSceneAsync(SceneLoadInfo sceneLoadInfo)
        {
            SceneLoadResult sceneLoadResult = await _sceneNavigationService.LoadSceneAsync(sceneLoadInfo);
            if (sceneLoadResult.IsSuccess)
            {
                bool hasScene = _activeScenes.Any(a => a.SceneName == sceneLoadInfo.SceneName);
                if (!hasScene)
                {
                    _activeScenes.Add(new SceneInfo(sceneLoadInfo.SceneName));
                }
            }
            
            return sceneLoadResult;
        }

        public async UniTask<SceneLoadResult> UnloadSceneAsync(SceneUnloadInfo sceneUnloadInfo)
        {
            SceneLoadResult sceneLoadResult = await _sceneNavigationService.UnloadSceneAsync(sceneUnloadInfo);
            if (sceneLoadResult.IsSuccess)
            {
                for (int index = 0; index < _activeScenes.Count; index++)
                {
                    SceneInfo activeScene = _activeScenes[index];
                    if (activeScene.SceneName == sceneUnloadInfo.SceneName)
                    {
                        _activeScenes.RemoveAt(index);
                        break;
                    }
                }
            }
            
            return sceneLoadResult;
        }
    }
}