using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    [CreateAssetMenu(menuName =  "VertigoGames/EquipmentModule/Gun Reward Data")]
    public class GunRewardData : RewardTypeData
    {
        public GunName gunName;

        public GunTier tier;
    }
}