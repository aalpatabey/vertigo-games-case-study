namespace VertigoGames.SerializationModule.Runtime.Scripts
{
    public readonly struct JSONSerializationData : ISerializationData
    {
        public readonly string Json;

        public JSONSerializationData(string json)
        {
            Json = json;
        }
    }
}