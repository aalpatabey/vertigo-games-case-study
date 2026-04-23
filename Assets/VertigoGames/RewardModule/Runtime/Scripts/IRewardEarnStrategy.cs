namespace VertigoGames.RewardModule.Runtime.Scripts
{
    public interface IRewardEarnStrategy
    {
        bool CanEarn(in RewardEarnInfo rewardEarnInfo);
        void Earn(in RewardEarnInfo rewardEarnInfo);
    }
}