namespace VertigoGames.UserModule.Runtime.Scripts
{
    public class UserDataSaver
    {
        private readonly UserData _userData;

        private readonly UserDataStoreController _userDataStoreController;
        
        public UserDataSaver(UserData userData, UserDataStoreController userDataStoreController)
        {
            _userData = userData;
            _userDataStoreController = userDataStoreController;
        }

        public void SaveUserDataToLocal()
        {
            _userDataStoreController.SaveUserDataAsync(UserDataLoadType.Local, _userData);
        }
    }
}