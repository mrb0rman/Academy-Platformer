using System;
using UnityEngine;
using DG.Tweening;

namespace UIService
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        private const float Duration = 1f;
        private Tween _showAnimation;
        private Tween _hideAnimation;
        
        public void Show()
        {
            _showAnimation?.Kill();
            _showAnimation = transform.DOScale(Vector3.one, Duration);
        }

        public void Hide()
        {
            _hideAnimation?.Kill();
            _hideAnimation = transform.DOScale(Vector3.zero, Duration);
        }
    }
}