using DG.Tweening;
using UnityEngine;

namespace UIService
{
    public class UIAnimationWindow : UIWindow
    {
        private const float Duration = 5f;
        
        private Tween _showAnimation;
        private Tween _hideAnimation;
        public override void Show()
        {
            _showAnimation?.Kill();
            _showAnimation = transform
                .DOScale(Vector3.one, Duration)
                .OnComplete(() =>
                {
                    OnShowEvent.Invoke();
                });
        }

        public override void Hide()
        {
            _hideAnimation?.Kill();
            _hideAnimation = transform
                .DOScale(Vector3.zero, Duration)
                .OnComplete(() =>
                {
                    OnHideEvent.Invoke();
                });
        }
    }
}