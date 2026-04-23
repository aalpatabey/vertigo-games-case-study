using Cysharp.Threading.Tasks;
using UnityEngine;
using VertigoGames.SaveLoadModule.Runtime.Scripts;
using VertigoGames.SerializationModule.Runtime.Scripts;

namespace VertigoGames.UserModule.Runtime.Scripts
{
    public class LocalUserDataStore : IUserDataStoreStrategy
    {
        private SerializationController _serializationController;

        public LocalUserDataStore(SerializationController serializationController)
        {
            _serializationController = serializationController;
        }

        public bool CanStore(UserDataLoadType userDataLoadType)
        {
            return userDataLoadType == UserDataLoadType.Local;
        }

        public UniTask<UserData> LoadAsync()
        {
            string serialized = PlayerPrefs.GetString(PlayerPrefsKeys.USER_DATA_KEY);

            UserData userData = _serializationController.Deserialize<JSONSerializationData, UserData>(new JSONSerializationData(serialized));
            return UniTask.FromResult(userData);
        }

        public UniTask SaveAsync(UserData userData)
        {
            JSONSerializationData jsonSerializationData = _serializationController.Serialize<JSONSerializationData, UserData>(userData);
            
            PlayerPrefs.SetString(PlayerPrefsKeys.USER_DATA_KEY, jsonSerializationData.Json);
            
            return UniTask.CompletedTask;
        }
    }
}