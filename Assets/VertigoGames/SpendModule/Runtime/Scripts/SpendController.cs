using System.Collections.Generic;
using VertigoGames.UserModule.Runtime.Scripts;

namespace VertigoGames.SpendModule.Runtime.Scripts
{
    public class SpendController
    {
        private readonly IReadOnlyList<ISpendStrategy> _spendStrategies;

        private readonly UserDataSaver _userDataSaver;

        public SpendController(IReadOnlyList<ISpendStrategy> spendStrategies, UserDataSaver userDataSaver)
        {
            _spendStrategies = spendStrategies;
            _userDataSaver = userDataSaver;
        }

        public bool TrySpend(in SpendInfo spendInfo)
        {
            for (int index = 0; index < _spendStrategies.Count; index++)
            {
                ISpendStrategy spendStrategy = _spendStrategies[index];
                if (spendStrategy.CanSpend(spendInfo))
                {
                    bool trySpend = spendStrategy.TrySpend(spendInfo);
                    if (trySpend)
                    {
                        _userDataSaver.SaveUserDataToLocal();
                    }
                    
                    return trySpend;
                }
            }
            
            return false;
        }
    }
}