namespace VertigoGames.SerializationModule.Runtime.Scripts
{
    public interface ISerializationStrategy<T> : ISerializationStrategy where T : ISerializationData
    {
        T Serialize<TData>(TData data);
        TData Deserialize<TData>(T serializationData);
    }

    public interface ISerializationStrategy
    {
        
    }
}