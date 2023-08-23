﻿using DG.Tweening;

namespace UIService
{
    public class UIAnimationWindow : UIWindow
    {
        private const float Duration = 1f;
        
        private Tween _showAnimation;
        private Tween _hideAnimation;
        public override void Show()
        {
            _showAnimation?.Kill();
            
            _showAnimation = transform
                .DOMoveY(-5, Duration).SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    OnShowEvent.Invoke();
                });
                
        }

        public override void Hide()
        {
            var transformLocalPosition = transform.localPosition;
            
            _hideAnimation?.Kill();
            _hideAnimation = transform
                .DOMoveY(-transformLocalPosition.y*2, Duration)
                .OnComplete(() =>
                {
                    OnHideEvent.Invoke();
                });
        }
    }
}