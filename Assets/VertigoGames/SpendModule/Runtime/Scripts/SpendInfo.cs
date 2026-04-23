namespace VertigoGames.SpendModule.Runtime.Scripts
{
    public readonly struct SpendInfo
    {
        public readonly SpendType SpendType;
        
        public readonly int Amount;

        public SpendInfo(SpendType spendType, int amount)
        {
            SpendType = spendType;
            Amount = amount;
        }
    }
}