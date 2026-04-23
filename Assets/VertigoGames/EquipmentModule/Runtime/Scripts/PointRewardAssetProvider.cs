using System;
using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    public class PointRewardAssetProvider : MonoBehaviour, IRewardAssetProviderStrategy
    {
        public AssetInfo[] asset;
        
        public bool CanProvide(RewardData rewardData)
        {
            return rewardData.rewardTypeData is PointRewardTypeData;
        }

        public RewardAssetInfo GetRewardAssetInfo(RewardData rewardData)
        {
            PointRewardTypeData rewardDataRewardTypeData = (PointRewardTypeData)rewardData.rewardTypeData;
            for (int index = 0; index < asset.Length; index++)
            {
                AssetInfo assetInfo = asset[index];
                if (assetInfo.pointType == rewardDataRewardTypeData.pointType)
                {
                    return new RewardAssetInfo(assetInfo.icon);
                }
            }

            return default;
        }
        
        [Serializable]
        public struct AssetInfo
        {
            public PointType pointType;
            public Sprite icon;
        }
    }
}