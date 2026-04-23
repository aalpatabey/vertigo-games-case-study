using System;
using UnityEngine;
using UnityEngine.UI;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class RewardsCollectedArea : MonoBehaviour
    {
        [SerializeField]
        private Button _collectAndRestartButton;

        private Action _onCollectedCallback;
        
        private void OnEnable()
        {
            SubscribeEvents(true);
        }

        private void OnDisable()
        {
            SubscribeEvents(false);
        }

        public void Display(Action onCollectedCallback)
        {
            _onCollectedCallback = onCollectedCallback;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _onCollectedCallback = null;
        }

        private void SubscribeEvents(bool value)
        {
            if (value)
            {
                _collectAndRestartButton.onClick.AddListener(OnCollected);
            }
            else
            {
                _collectAndRestartButton.onClick.RemoveListener(OnCollected);
            }
        }

        private void OnCollected()
        {
            _onCollectedCallback?.Invoke();
        }
    }
}