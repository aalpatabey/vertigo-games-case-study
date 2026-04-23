using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using VertigoGames.SceneNavigationModule.Runtime.Scripts;

namespace VertigoGames.SplashModule.Runtime.Scripts
{
    public class SplashLoader : IInitializable
    {
        private readonly IReadOnlyList<ISplashInitializable> _splashInitializables;

        private readonly SceneNavigationController _sceneNavigationController;

        public SplashLoader(IReadOnlyList<ISplashInitializable> splashInitializables, SceneNavigationController sceneNavigationController)
        {
            _splashInitializables = splashInitializables;
            _sceneNavigationController = sceneNavigationController;
        }

        public async UniTaskVoid LoadSplashAsync()
        {
            List<UniTask> loadingTasks = new List<UniTask>();
            
            SplashInitializeInfo splashInitializeInfo = new SplashInitializeInfo();
            
            for (int index = 0; index < _splashInitializables.Count; index++)
            {
                ISplashInitializable splashInitializable = _splashInitializables[index];
                loadingTasks.Add(splashInitializable.InitializeAsync(splashInitializeInfo));
            }
            
            await UniTask.WhenAll(loadingTasks);

            await _sceneNavigationController.LoadSceneAsync(new SceneLoadInfo(SceneName.Gameplay, LoadSceneMode.Single));
        }

        public void Initialize()
        {
            LoadSplashAsync().Forget();
        }
    }
}