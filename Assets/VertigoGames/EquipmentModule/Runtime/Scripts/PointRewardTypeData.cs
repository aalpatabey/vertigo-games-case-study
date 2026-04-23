using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    [CreateAssetMenu(menuName = "VertigoGames/EquipmentModule/PointReward Type")]
    public class PointRewardTypeData : RewardTypeData
    {
        public PointType pointType;
    }
}