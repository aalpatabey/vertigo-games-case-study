namespace VertigoGames.RewardModule.Runtime.Scripts
{
    public readonly struct RewardEarnInfo
    {
        public readonly RewardTypeData RewardTypeData;

        public readonly int Amount;

        public RewardEarnInfo(RewardData rewardData)
        {
            Amount = rewardData.amount;
            RewardTypeData = rewardData.rewardTypeData;
        }

        public RewardEarnInfo(RewardTypeData rewardTypeData, int amount)
        {
            RewardTypeData = rewardTypeData;
            Amount = amount;
        }
    }
}