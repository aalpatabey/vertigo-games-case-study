using System.Collections.Generic;

namespace VertigoGames.RewardModule.Runtime.Scripts
{
    public class RewardAssetProvider
    {
        private readonly IReadOnlyList<IRewardAssetProviderStrategy> _rewardAssetProviderStrategies;

        public RewardAssetProvider(IReadOnlyList<IRewardAssetProviderStrategy> rewardAssetProviderStrategies)
        {
            _rewardAssetProviderStrategies = rewardAssetProviderStrategies;
        }

        public RewardAssetInfo GetRewardAssetInfo(RewardData rewardData)
        {
            for (int index = 0; index < _rewardAssetProviderStrategies.Count; index++)
            {
                IRewardAssetProviderStrategy rewardAssetProviderStrategy = _rewardAssetProviderStrategies[index];
                if (rewardAssetProviderStrategy.CanProvide(rewardData))
                {
                    return rewardAssetProviderStrategy.GetRewardAssetInfo(rewardData);
                }
            }
            
            return default;
        }
    }
}