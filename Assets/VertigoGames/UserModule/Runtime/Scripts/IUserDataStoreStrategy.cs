using Cysharp.Threading.Tasks;

namespace VertigoGames.UserModule.Runtime.Scripts
{
    public interface IUserDataStoreStrategy
    {
        bool CanStore(UserDataLoadType userDataLoadType);
        
        UniTask<UserData> LoadAsync();
        UniTask SaveAsync(UserData userData);
    }
}