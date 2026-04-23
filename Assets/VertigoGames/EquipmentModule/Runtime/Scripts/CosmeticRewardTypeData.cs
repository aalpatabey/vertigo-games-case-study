using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    [CreateAssetMenu(menuName = "VertigoGames/EquipmentModule/CosmeticReward Type")]
    public class CosmeticRewardTypeData : RewardTypeData
    {
        public CosmeticType cosmeticType;
    }
}