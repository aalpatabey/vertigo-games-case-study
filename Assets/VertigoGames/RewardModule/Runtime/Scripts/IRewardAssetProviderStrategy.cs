using UnityEngine;

namespace VertigoGames.RewardModule.Runtime.Scripts
{
    public interface IRewardAssetProviderStrategy
    {
        bool CanProvide(RewardData rewardData);
        
        RewardAssetInfo GetRewardAssetInfo(RewardData rewardData);
    }
}