using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    [CreateAssetMenu(menuName = "VertigoGames/EquipmentModule/ConsumableReward Type")]
    public class ConsumableRewardTypeData : RewardTypeData
    {
        public ConsumableType consumableType;
    }
}