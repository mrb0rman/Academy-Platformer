using System;
using UnityEngine;
using DG.Tweening;

namespace UIServiceNamespace
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        private float duration = 1f;
        private Sequence showAnimation;
        private Sequence hideAnimation;
        
        public void Show()
        {
            showAnimation?.Kill();
            showAnimation = DOTween.Sequence();
            showAnimation.Append(this.transform.DOScale(Vector3.one, duration));
            showAnimation = DOTween.Sequence();
        }

        public void Hide()
        {
            hideAnimation?.Kill();
            hideAnimation = DOTween.Sequence();
            hideAnimation.Append(this.transform.DOScale(Vector3.zero, duration));
            hideAnimation = DOTween.Sequence();
        }
    }
}