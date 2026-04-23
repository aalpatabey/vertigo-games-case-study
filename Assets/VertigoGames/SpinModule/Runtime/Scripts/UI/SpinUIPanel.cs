using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Factory;
using VertigoGames.RewardModule.Runtime.Scripts;
using VertigoGames.SpinModule.Runtime.Scripts.Model;
using Random = UnityEngine.Random;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class SpinUIPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _spinButton;
        [SerializeField]
        private Button _exitButton;

        [Inject]
        private SpinDataList _spinDataList;

        [Inject]
        private DefaultPrefabFactory<CollectedSpinRewardView> _defaultPrefabFactory;

        [SerializeField]
        private SpinRewardView[] _spinRewardViews;

        [SerializeField]
        private CollectedSpinRewardView _collectedSpinRewardViewPrefab;
        
        [SerializeField]
        private Transform _collectedRewardsParent;

        [SerializeField]
        private Transform _wheel;
        
        [SerializeField]
        private SpinStepArea _spinStepArea;
        
        [SerializeField]
        private BombExplodedArea _bombExplodedArea;
        
        [SerializeField]
        private RewardsCollectedArea _rewardsCollectedArea;

        [Inject]
        private RewardEarnController _rewardEarnController;
        
        private int _currentStepIndex = 0;
        
        private SpinStepData _currentStepData;
        
        private readonly Dictionary<RewardTypeData, int> _collectedRewards = new Dictionary<RewardTypeData, int>();
        private readonly Dictionary<RewardTypeData, CollectedSpinRewardView> _collectedRewardViews = new Dictionary<RewardTypeData, CollectedSpinRewardView>();

        private void OnEnable()
        {
            ResetSpin();

            SubscribeEvents(true);
        }

        private void ResetSpin()
        {
            _bombExplodedArea.Hide();
            _rewardsCollectedArea.Hide();
            
            UpdateStep(0);
            _spinStepArea.InitializeSteps();
            _spinButton.gameObject.SetActive(true);
            _wheel.transform.eulerAngles = Vector3.zero;
            _exitButton.gameObject.SetActive(true);
            
            _collectedRewards.Clear();
            foreach (KeyValuePair<RewardTypeData, CollectedSpinRewardView> collectedSpinRewardView in _collectedRewardViews)
            {
                Destroy(collectedSpinRewardView.Value.gameObject);
            }
            
            _collectedRewardViews.Clear();
        }

        private void UpdateStep(int stepIndex)
        {
            _currentStepIndex = stepIndex;
            
            SpinStepData spinStepData = _spinDataList.GetStep(stepIndex);
            _currentStepData = spinStepData;
            
            for (int index = 0; index < spinStepData.rewards.Length; index++)
            {
                SpinRewardData spinRewardData = spinStepData.rewards[index];
                _spinRewardViews[index].UpdateView(spinRewardData);
            }
            
            _spinButton.gameObject.SetActive(true);
            _wheel.transform.eulerAngles = Vector3.zero;
        }

        private void SubscribeEvents(bool value)
        {
            if (value)
            {
                _spinButton.onClick.AddListener(OnSpinButtonClicked);
                _exitButton.onClick.AddListener(OnExit);
            }
            else
            {
                _spinButton.onClick.RemoveListener(OnSpinButtonClicked);
                _exitButton.onClick.RemoveListener(OnExit);
            }
        }

        private void OnExit()
        {
            _wheel.DOKill();
            
            foreach (KeyValuePair<RewardTypeData, int> collectedRewardPair in _collectedRewards)
            {
                _rewardEarnController.Earn(new RewardEarnInfo(collectedRewardPair.Key, collectedRewardPair.Value));
            }

            _rewardsCollectedArea.Display(OnRewardsCollected);
        }

        private void OnRewardsCollected()
        {
            ResetSpin();
        }

        private void OnSpinButtonClicked()
        {
            _spinButton.gameObject.SetActive(false);
            
            const float duration = 3;
            const float extraSpins = 2;
            
            float currentZ = _wheel.eulerAngles.z;

            SelectedSpinRewardInfo selectedSpinRewardInfo = GetRandomSpinRewardInfo();
            int selectedRewardIndex = selectedSpinRewardInfo.StepIndex;
            if (selectedRewardIndex == -1)
            {
                throw new IndexOutOfRangeException("Selected reward index is out of range.");
            }
            
            float targetAngle = selectedRewardIndex * 45;
            float deltaToTarget = Mathf.DeltaAngle(currentZ, targetAngle);

            if (deltaToTarget > 0)
            {
                deltaToTarget -= 360f;
            }

            float totalRotation = 360f * extraSpins + Mathf.Abs(deltaToTarget);

            _wheel
                .DORotate(
                    new Vector3(0, 0, currentZ - totalRotation),
                    duration,
                    RotateMode.FastBeyond360
                )
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    if (selectedSpinRewardInfo.SpinRewardData.IsBomb())
                    {
                        OnBombCollected();
                    }
                    else
                    {
                        OnStepCollected(selectedSpinRewardInfo);
                    }
                });
        }

        private void OnBombCollected()
        {
            _exitButton.gameObject.SetActive(false);
            _bombExplodedArea.Display(OnRevived, OnGaveUp);
        }

        private void OnRevived()
        {
            _exitButton.gameObject.SetActive(true);
            _bombExplodedArea.Hide();
            
            UpdateStep(_currentStepIndex);
        }

        private void OnGaveUp()
        {
            ResetSpin();
        }

        private void OnStepCollected(SelectedSpinRewardInfo selectedSpinRewardInfo)
        {
            RewardData rewardData = selectedSpinRewardInfo.SpinRewardData.reward;
            if (_collectedRewards.ContainsKey(rewardData.rewardTypeData))
            {
                _collectedRewards[rewardData.rewardTypeData] += rewardData.amount;
            }
            else
            {
                _collectedRewards.Add(rewardData.rewardTypeData, rewardData.amount);
            }

            if (_collectedRewardViews.ContainsKey(rewardData.rewardTypeData))
            {
                CollectedSpinRewardView collectedSpinRewardView = _collectedRewardViews[rewardData.rewardTypeData];
                collectedSpinRewardView.UpdateAmount(_collectedRewards[rewardData.rewardTypeData]);
            }
            else
            {
                CollectedSpinRewardView collectedSpinRewardView = _defaultPrefabFactory.Instantiate(_collectedSpinRewardViewPrefab, _collectedRewardsParent);
                collectedSpinRewardView.UpdateReward(rewardData);
                collectedSpinRewardView.UpdateAmount(rewardData.amount);
                _collectedRewardViews.Add(rewardData.rewardTypeData, collectedSpinRewardView);
            }

            _spinStepArea.PlayNextStepAnimation().onComplete += OnNextStepAnimationCompleted;
        }

        private void OnNextStepAnimationCompleted()
        {
            _currentStepIndex++;
            UpdateStep(_currentStepIndex);
        }

        private SelectedSpinRewardInfo GetRandomSpinRewardInfo()
        {
            int totalPossibility = 0;
            
            for (int index = 0; index < _currentStepData.rewards.Length; index++)
            {
                SpinRewardData spinRewardData = _currentStepData.rewards[index];
                totalPossibility += spinRewardData.possibility;
            }

            int randomNumberInPossibilityRange = Random.Range(1, totalPossibility + 1);

            int accumulatedPossibilityToCheck = 0;
            for (int index = 0; index < _currentStepData.rewards.Length; index++)
            {
                SpinRewardData spinRewardData = _currentStepData.rewards[index];
                accumulatedPossibilityToCheck += spinRewardData.possibility;
                
                if (accumulatedPossibilityToCheck >= randomNumberInPossibilityRange)
                {
                    return new SelectedSpinRewardInfo(index, spinRewardData);
                }
            }
            
            return new SelectedSpinRewardInfo(-1, null);
        }

        private void OnDisable()
        {
            SubscribeEvents(false);
        }
    }
}
