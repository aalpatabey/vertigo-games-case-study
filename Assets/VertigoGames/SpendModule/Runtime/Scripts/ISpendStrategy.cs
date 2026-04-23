namespace VertigoGames.SpendModule.Runtime.Scripts
{
    public interface ISpendStrategy
    {
        bool CanSpend(in SpendInfo spendInfo);
        bool TrySpend(in SpendInfo spendInfo);
    }
}