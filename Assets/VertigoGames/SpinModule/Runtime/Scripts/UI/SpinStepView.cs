using TMPro;
using UnityEngine;
using VertigoGames.ObjectPoolingModule.Runtime.Scripts;
using VertigoGames.SpinModule.Runtime.Scripts.Utility;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class SpinStepView : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private TMP_Text _text;
        
        [SerializeField]
        private Color _safeZoneColor;
        [SerializeField]
        private Color _superZoneColor;
        [SerializeField]
        private Color _defaultColor;
        
        public int CurrentStepIndex { get; private set; }
        
        public void OnTakeFromPool()
        {
            gameObject.SetActive(true);
        }

        public void UpdateView(int stepIndex, int activeStepIndex)
        {
            CurrentStepIndex = stepIndex;
            _text.text = stepIndex.ToString();
            _text.gameObject.SetActive(stepIndex > 0);
            Color textColor = GetTextColor(stepIndex);
            textColor.a = stepIndex < activeStepIndex ? 0.5f : 1f;
            _text.color = textColor;
        }

        private Color GetTextColor(int stepIndex)
        {
            if (SpinHelper.IsSafeZone(stepIndex))
            {
                return _safeZoneColor;
            }

            if (SpinHelper.IsSuperZone(stepIndex))
            {
                return _superZoneColor;
            }
            
            return _defaultColor;
        }

        public void OnReturnedToPool()
        {
            gameObject.SetActive(false);
        }
    }
}