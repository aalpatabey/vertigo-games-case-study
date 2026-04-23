using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Factory;
using VertigoGames.RewardModule.Runtime.Scripts;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class CollectedSpinRewardView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;
        
        [SerializeField]
        private TMP_Text _amountText;

        [Inject]
        private RewardAssetProvider _rewardAssetProvider;
        
        public void UpdateReward(RewardData rewardData)
        {
            RewardAssetInfo rewardAssetInfo = _rewardAssetProvider.GetRewardAssetInfo(rewardData);
            _icon.sprite = rewardAssetInfo.RewardSprite;
        }

        public void UpdateAmount(int amount)
        {
            _amountText.text = amount.ToString();
        }
    }
}