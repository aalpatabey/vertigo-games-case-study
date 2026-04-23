using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Factory;
using VertigoGames.ObjectPoolingModule.Runtime.Scripts;

namespace VertigoGames.SpinModule.Runtime.Scripts.UI
{
    public class SpinStepArea : MonoBehaviour
    {
        private List<SpinStepView> _spinStepViews;
        
        private RectTransform _rectTransform;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void InitializeSteps()
        {
            _spinStepViews ??= GetComponentsInChildren<SpinStepView>().ToList();
            int initialValue = (-_spinStepViews.Count + 1) / 2 + 1;
            int currentStepIndex = initialValue + (_spinStepViews.Count - 1) / 2;

            for (int index = 0; index < _spinStepViews.Count; index++)
            {
                SpinStepView spinStepView = _spinStepViews[index];
                spinStepView.UpdateView(initialValue + index, currentStepIndex);
            }
        }

        public Tween PlayNextStepAnimation()
        {
            TweenerCore<Vector2, Vector2, VectorOptions> playNextStepAnimation = _rectTransform.DOAnchorPosX(-50, 0.5f);
            playNextStepAnimation.onComplete += MoveFirstToLast;
            return playNextStepAnimation;
        }

        private void MoveFirstToLast()
        {
            SpinStepView first = _spinStepViews[0];
            SpinStepView last = _spinStepViews[^1];
            SpinStepView spinnedStepView = _spinStepViews[(_spinStepViews.Count - 1) / 2];

            _spinStepViews.RemoveAt(0);
            _spinStepViews.Add(first);
            
            SpinStepView activeStepView = _spinStepViews[(_spinStepViews.Count - 1) / 2];
            int currentStepIndex = activeStepView.CurrentStepIndex;
            spinnedStepView.UpdateView(spinnedStepView.CurrentStepIndex, currentStepIndex);

            first.UpdateView(last.CurrentStepIndex + 1, currentStepIndex);
            first.transform.SetAsLastSibling();
            _rectTransform.anchoredPosition = new Vector2(0, 0);
            
            LayoutRebuilder.MarkLayoutForRebuild(_rectTransform);
        }
    }
}