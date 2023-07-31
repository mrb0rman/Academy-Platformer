using System;
using UnityEngine;
using DG.Tweening;

namespace UIService
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        private const float duration = 1f;
        private Tween _showAnimation;
        private Tween _hideAnimation;
        
        public void Show()
        {
            _showAnimation?.Kill();
            _showAnimation = this.transform.DOScale(Vector3.one, duration);
        }

        public void Hide()
        {
            _hideAnimation?.Kill();
            _hideAnimation = this.transform.DOScale(Vector3.zero, duration);
        }
    }
}