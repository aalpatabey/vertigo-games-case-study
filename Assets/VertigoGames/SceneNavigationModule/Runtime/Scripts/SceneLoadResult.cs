namespace VertigoGames.SceneNavigationModule.Runtime.Scripts
{
    public readonly struct SceneLoadResult
    {
        public readonly bool IsSuccess;
        
        private SceneLoadResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public static SceneLoadResult Fail()
        {
            return new SceneLoadResult(false);
        }

        public static SceneLoadResult Success()
        {
            return new SceneLoadResult(true);
        }
    }
}