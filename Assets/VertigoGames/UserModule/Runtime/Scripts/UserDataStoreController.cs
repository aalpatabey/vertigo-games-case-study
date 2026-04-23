using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace VertigoGames.UserModule.Runtime.Scripts
{
    public class UserDataStoreController
    {
        private readonly IReadOnlyList<IUserDataStoreStrategy> _userDataLoadStrategies;

        public UserDataStoreController(IReadOnlyList<IUserDataStoreStrategy> userDataLoadStrategies)
        {
            _userDataLoadStrategies = userDataLoadStrategies;
        }

        public UniTask<UserData> LoadUserDataAsync(UserDataLoadType userDataLoadType)
        {
            for (int index = 0; index < _userDataLoadStrategies.Count; index++)
            {
                IUserDataStoreStrategy userDataStoreStrategy = _userDataLoadStrategies[index];
                if (userDataStoreStrategy.CanStore(userDataLoadType))
                {
                    return userDataStoreStrategy.LoadAsync();
                }
            }
            
            return UniTask.FromResult(default(UserData));
        }

        public UniTask SaveUserDataAsync(UserDataLoadType userDataLoadType, UserData userData)
        {
            for (int index = 0; index < _userDataLoadStrategies.Count; index++)
            {
                IUserDataStoreStrategy userDataStoreStrategy = _userDataLoadStrategies[index];
                if (userDataStoreStrategy.CanStore(userDataLoadType))
                {
                    return userDataStoreStrategy.SaveAsync(userData);
                }
            }

            return UniTask.CompletedTask;
        }
    }
}