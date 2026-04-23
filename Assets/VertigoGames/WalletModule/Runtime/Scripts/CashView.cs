using System;
using TMPro;
using UnityEngine;
using VContainer;

namespace VertigoGames.WalletModule.Runtime.Scripts
{
    public class CashView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _amountText;

        [Inject]
        private CashController _cashController;

        private void OnEnable()
        {
            UpdateAmountText();
            SubscribeEvents(true);
        }

        private void OnDisable()
        {
            SubscribeEvents(false);
        }

        private void SubscribeEvents(bool value)
        {
            if (value)
            {
                _cashController.OnCashCountChangedEvent += UpdateAmountText;
            }
            else
            {
                _cashController.OnCashCountChangedEvent -= UpdateAmountText;
            }
        }

        private void UpdateAmountText()
        {
            _amountText.text = _cashController.CashCount.ToString();
        }
    }
}