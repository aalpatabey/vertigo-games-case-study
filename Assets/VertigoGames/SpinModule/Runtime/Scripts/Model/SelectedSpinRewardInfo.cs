namespace VertigoGames.SpinModule.Runtime.Scripts.Model
{
    public readonly struct SelectedSpinRewardInfo
    {
        public readonly int StepIndex;
        
        public readonly SpinRewardData SpinRewardData;

        public SelectedSpinRewardInfo(int stepIndex, SpinRewardData spinRewardData)
        {
            StepIndex = stepIndex;
            SpinRewardData = spinRewardData;
        }
    }
}