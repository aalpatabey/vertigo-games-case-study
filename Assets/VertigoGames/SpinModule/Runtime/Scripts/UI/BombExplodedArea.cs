using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VertigoGames.SpendModule.Runtime.Scripts;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class BombExplodedArea : MonoBehaviour
    {
        [SerializeField]
        private Button _giveUpButton;
        [SerializeField]
        private Button _reviveButton;

        [SerializeField]
        private TMP_Text _reviveCashText;

        [SerializeField]
        private TMP_Text _notEnoughCashText;

        [Inject]
        private SpendController _spendController;

        private const int REVIVE_CASH_AMOUNT = 500;

        private Action _onGaveUpAction;
        private Action _onRevivedAction;
        
        private void OnEnable()
        {
            SubscribeEvents(true);
        }

        private void OnDisable()
        {
            SubscribeEvents(false);
        }

        public void Display(Action onRevived, Action onGaveUp)
        {
            _onRevivedAction = onRevived;
            _onGaveUpAction = onGaveUp;
            
            _reviveCashText.text = REVIVE_CASH_AMOUNT.ToString();
            _notEnoughCashText.DOKill();
            _notEnoughCashText.alpha = 0;
            
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            _onRevivedAction = null;
            _onGaveUpAction = null;
        }

        private void SubscribeEvents(bool value)
        {
            if (value)
            {
                _giveUpButton.onClick.AddListener(OnGaveUp);
                _reviveButton.onClick.AddListener(OnRevived);
            }
            else
            {
                _giveUpButton.onClick.RemoveListener(OnGaveUp);
                _reviveButton.onClick.RemoveListener(OnRevived);
            }
        }

        private void OnRevived()
        {
            if (_spendController.TrySpend(new SpendInfo(SpendType.Cash, REVIVE_CASH_AMOUNT)))
            {
                _onRevivedAction?.Invoke();
            }
            else
            {
                _notEnoughCashText.DOFade(1, 0.5f).From(0).SetLoops(2, LoopType.Yoyo);
            }
        }

        private void OnGaveUp()
        {
            _onGaveUpAction?.Invoke();
        }
    }
}