using UnityEngine.SceneManagement;

namespace VertigoGames.SceneNavigationModule.Runtime.Scripts
{
    public readonly struct SceneLoadInfo
    {
        public readonly SceneName SceneName;

        public readonly LoadSceneMode LoadSceneMode;
        
        public SceneLoadInfo(SceneName sceneName, LoadSceneMode loadSceneMode)
        {
            SceneName = sceneName;
            LoadSceneMode = loadSceneMode;
        }
    }
}