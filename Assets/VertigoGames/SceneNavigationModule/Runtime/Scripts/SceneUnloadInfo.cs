namespace VertigoGames.SceneNavigationModule.Runtime.Scripts
{
    public readonly struct SceneUnloadInfo
    {
        public readonly SceneName SceneName;

        public SceneUnloadInfo(SceneName sceneName)
        {
            SceneName = sceneName;
        }
    }
}