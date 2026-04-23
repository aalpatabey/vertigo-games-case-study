using VertigoGames.RewardModule.Runtime.Scripts;
using VertigoGames.SpendModule.Runtime.Scripts;

namespace VertigoGames.WalletModule.Runtime.Scripts
{
    public class CashRewardEarnAndSpendStrategy : IRewardEarnStrategy, ISpendStrategy
    {
        private readonly CashController _cashController;

        public CashRewardEarnAndSpendStrategy(CashController cashController)
        {
            _cashController = cashController;
        }

        public bool CanEarn(in RewardEarnInfo rewardEarnInfo)
        {
            return rewardEarnInfo.RewardTypeData is CashRewardData;
        }

        public void Earn(in RewardEarnInfo rewardEarnInfo)
        {
            _cashController.AddCash(rewardEarnInfo.Amount);
        }

        public bool CanSpend(in SpendInfo spendInfo)
        {
            return spendInfo.SpendType == SpendType.Cash;
        }

        public bool TrySpend(in SpendInfo spendInfo)
        {
            if (_cashController.CashCount >= spendInfo.Amount)
            {
                _cashController.AddCash(-spendInfo.Amount);
                return true;
            }
            
            return false;
        }
    }
}