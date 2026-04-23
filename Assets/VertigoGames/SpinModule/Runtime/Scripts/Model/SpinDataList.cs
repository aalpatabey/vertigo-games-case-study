using UnityEngine;

namespace VertigoGames.SpinModule.Runtime.Scripts.Model
{
    [CreateAssetMenu(menuName = "VertigoGames/SpinModule/SpinDataList")]
    public class SpinDataList : ScriptableObject
    {
        public SpinStepData[] steps;
        
        public SpinStepData GetStep(int step)
        {
            if (steps != null && steps.Length != 0)
            {
                int index = step % steps.Length;

                return steps[index];
            }

            return null;
        }
    }
}