using System;
using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    public class CosmeticRewardAssetProvider : MonoBehaviour, IRewardAssetProviderStrategy
    {
        public AssetInfo[] asset;
        
        public bool CanProvide(RewardData rewardData)
        {
            return rewardData.rewardTypeData is CosmeticRewardTypeData;
        }

        public RewardAssetInfo GetRewardAssetInfo(RewardData rewardData)
        {
            CosmeticRewardTypeData rewardDataRewardTypeData = (CosmeticRewardTypeData)rewardData.rewardTypeData;
            for (int index = 0; index < asset.Length; index++)
            {
                AssetInfo assetInfo = asset[index];
                if (assetInfo.cosmeticType == rewardDataRewardTypeData.cosmeticType)
                {
                    return new RewardAssetInfo(assetInfo.icon);
                }
            }

            return default;
        }
        
        [Serializable]
        public struct AssetInfo
        {
            public CosmeticType cosmeticType;
            public Sprite icon;
        }
    }
}