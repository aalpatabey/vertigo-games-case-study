using System.Collections.Generic;
using VertigoGames.UserModule.Runtime.Scripts;

namespace VertigoGames.RewardModule.Runtime.Scripts
{
    public class RewardEarnController
    {
        private readonly IReadOnlyList<IRewardEarnStrategy> _rewardEarnStrategies;
        
        private readonly UserDataSaver _userDataSaver;

        public RewardEarnController(IReadOnlyList<IRewardEarnStrategy> rewardEarnStrategies, UserDataSaver userDataSaver)
        {
            _rewardEarnStrategies = rewardEarnStrategies;
            _userDataSaver = userDataSaver;
        }

        public void Earn(in RewardEarnInfo rewardEarnInfo)
        {
            for (int index = 0; index < _rewardEarnStrategies.Count; index++)
            {
                IRewardEarnStrategy rewardEarnStrategy = _rewardEarnStrategies[index];
                if (rewardEarnStrategy.CanEarn(rewardEarnInfo))
                {
                    rewardEarnStrategy.Earn(rewardEarnInfo);
                    _userDataSaver.SaveUserDataToLocal();
                }
            }
        }
    }
}