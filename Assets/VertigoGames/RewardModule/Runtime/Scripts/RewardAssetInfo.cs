using UnityEngine;

namespace VertigoGames.RewardModule.Runtime.Scripts
{
    public readonly struct RewardAssetInfo
    {
        public readonly Sprite RewardSprite;

        public RewardAssetInfo(Sprite rewardSprite)
        {
            RewardSprite = rewardSprite;
        }
    }
}