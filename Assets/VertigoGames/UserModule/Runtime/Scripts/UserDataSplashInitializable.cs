using Cysharp.Threading.Tasks;
using VertigoGames.SplashModule.Runtime.Scripts;

namespace VertigoGames.UserModule.Runtime.Scripts
{
    public class UserDataSplashInitializable : ISplashInitializable
    {
        private readonly UserDataStoreController _userDataStoreController;
        
        private readonly UserDataHolder _userDataHolder;

        public UserDataSplashInitializable(UserDataStoreController userDataStoreController, UserDataHolder userDataHolder)
        {
            _userDataStoreController = userDataStoreController;
            _userDataHolder = userDataHolder;
        }

        public async UniTask InitializeAsync(SplashInitializeInfo splashInitializeInfo)
        {
            UserData loadUserDataAsync = await _userDataStoreController.LoadUserDataAsync(UserDataLoadType.Local);
            if (loadUserDataAsync == null)
            {
                loadUserDataAsync = new UserData()
                {
                    CashCount = 1000
                };
            }
            
            _userDataHolder.userData = loadUserDataAsync;
        }
    }
}