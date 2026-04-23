using System;
using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    public class GunAssetProvider : MonoBehaviour, IRewardAssetProviderStrategy
    {
        public AssetInfo[] asset;
        
        public bool CanProvide(RewardData rewardData)
        {
            return rewardData.rewardTypeData is GunRewardData;
        }

        public RewardAssetInfo GetRewardAssetInfo(RewardData rewardData)
        {
            GunRewardData rewardDataRewardTypeData = (GunRewardData)rewardData.rewardTypeData;
            for (int index = 0; index < asset.Length; index++)
            {
                AssetInfo assetInfo = asset[index];
                if (assetInfo.gunName == rewardDataRewardTypeData.gunName && assetInfo.gunTier == rewardDataRewardTypeData.tier)
                {
                    return new RewardAssetInfo(assetInfo.icon);
                }
            }

            return default;
        }
        
        [Serializable]
        public struct AssetInfo
        {
            public GunName gunName;
            public GunTier gunTier;
            public Sprite icon;
        }
    }
}