using System;
using UnityEngine;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.SpinModule.Runtime.Scripts.Model
{
    [Serializable]
    public class SpinRewardData
    {
        public RewardData reward;
        public int possibility;

        public bool IsBomb()
        {
            return reward.rewardTypeData == null;
        }
    }
}