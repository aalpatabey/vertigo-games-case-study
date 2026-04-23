using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.WalletModule.Runtime.Scripts
{
    public class CashRewardAssetProvider : MonoBehaviour, IRewardAssetProviderStrategy
    {
        [SerializeField]
        private Sprite _cashRewardSprite;
        
        public bool CanProvide(RewardData rewardData)
        {
            return rewardData.rewardTypeData is CashRewardData;
        }

        public RewardAssetInfo GetRewardAssetInfo(RewardData rewardData)
        {
            return new RewardAssetInfo(_cashRewardSprite);
        }
    }
}