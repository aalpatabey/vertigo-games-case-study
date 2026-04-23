using System;
using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    public class ConsumableRewardAssetProvider : MonoBehaviour, IRewardAssetProviderStrategy
    {
        public AssetInfo[] asset;
        
        public bool CanProvide(RewardData rewardData)
        {
            return rewardData.rewardTypeData is ConsumableRewardTypeData;
        }

        public RewardAssetInfo GetRewardAssetInfo(RewardData rewardData)
        {
            ConsumableRewardTypeData rewardDataRewardTypeData = (ConsumableRewardTypeData)rewardData.rewardTypeData;
            for (int index = 0; index < asset.Length; index++)
            {
                AssetInfo assetInfo = asset[index];
                if (assetInfo.consumableType == rewardDataRewardTypeData.consumableType)
                {
                    return new RewardAssetInfo(assetInfo.icon);
                }
            }

            return default;
        }
        
        [Serializable]
        public struct AssetInfo
        {
            public ConsumableType consumableType;
            public Sprite icon;
        }
    }
}