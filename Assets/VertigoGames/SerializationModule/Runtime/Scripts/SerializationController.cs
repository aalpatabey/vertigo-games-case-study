using System.Collections.Generic;

namespace VertigoGames.SerializationModule.Runtime.Scripts
{
    public class SerializationController
    {
        private readonly IReadOnlyList<ISerializationStrategy> _serializationStrategies;

        public SerializationController(IReadOnlyList<ISerializationStrategy> serializationStrategies)
        {
            _serializationStrategies = serializationStrategies;
        }

        public TSerializationData Serialize<TSerializationData, TData>(TData data) where TSerializationData : ISerializationData
        {
            for (int index = 0; index < _serializationStrategies.Count; index++)
            {
                ISerializationStrategy serializationStrategy = _serializationStrategies[index];
                if (serializationStrategy is ISerializationStrategy<TSerializationData> genericSerializationStrategy)
                {
                    return genericSerializationStrategy.Serialize(data);
                }
            }
            
            return default;
        }

        public TData Deserialize<TSerializationData, TData>(TSerializationData serializationData) where TSerializationData : ISerializationData
        {
            for (int index = 0; index < _serializationStrategies.Count; index++)
            {
                ISerializationStrategy serializationStrategy = _serializationStrategies[index];
                if (serializationStrategy is ISerializationStrategy<TSerializationData> genericSerializationStrategy)
                {
                    return genericSerializationStrategy.Deserialize<TData>(serializationData);
                }
            }
            
            return default;
        }
    }
}