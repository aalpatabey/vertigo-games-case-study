using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Utility;
using VertigoGames.RewardModule.Runtime.Scripts;
using VertigoGames.SpinModule.Runtime.Scripts.Model;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class SpinRewardView : MonoBehaviour
    {
        [Inject]
        private RewardAssetProvider _rewardAssetProvider;
        
        [SerializeField]
        private Image _icon;
        
        [SerializeField]
        private Sprite _bombIcon;
        
        [SerializeField]
        private TMP_Text _rewardText;

        public void UpdateView(SpinRewardData spinRewardData)
        {
            if (spinRewardData.IsBomb())
            {
                _icon.sprite = _bombIcon;
                _rewardText.gameObject.SetActive(false);
                return;
            }
            
            RewardAssetInfo rewardAssetInfo = _rewardAssetProvider.GetRewardAssetInfo(spinRewardData.reward);
            _icon.sprite = rewardAssetInfo.RewardSprite;
            _rewardText.text = "x" + spinRewardData.reward.amount.ToAbbreviatedText();

            _rewardText.gameObject.SetActive(true);
        }
    }
}