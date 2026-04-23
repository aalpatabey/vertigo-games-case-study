using UnityEngine;

namespace VertigoGames.SerializationModule.Runtime.Scripts
{
    public class JSONSerializationStrategy : ISerializationStrategy<JSONSerializationData>
    {
        public JSONSerializationData Serialize<TData>(TData data)
        {
            string json = JsonUtility.ToJson(data);
            return new JSONSerializationData(json);
        }

        public TData Deserialize<TData>(JSONSerializationData serializationData)
        {
            return JsonUtility.FromJson<TData>(serializationData.Json);
        }
    }
}