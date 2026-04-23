using System;
using VertigoGames.UserModule.Runtime.Scripts;

namespace VertigoGames.WalletModule.Runtime.Scripts
{
    public class CashController
    {
        private readonly UserData _userData;
        
        public int CashCount => _userData.CashCount;
        
        public event Action OnCashCountChangedEvent;

        public CashController(UserData userData)
        {
            _userData = userData;
        }

        public void AddCash(int amount)
        {
            _userData.CashCount += amount;
            OnCashCountChangedEvent?.Invoke();
        }
    }
}