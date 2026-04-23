using UnityEngine;

namespace VertigoGames.SpinModule.Runtime.Scripts.Model
{
    [CreateAssetMenu(menuName = "VertigoGames/SpinModule/SpinStepData")]
    public class SpinStepData : ScriptableObject
    {
        public SpinRewardData[] rewards;
    }
}