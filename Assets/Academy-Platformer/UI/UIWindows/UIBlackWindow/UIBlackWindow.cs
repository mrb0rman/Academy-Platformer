using DG.Tweening;
using UnityEngine;

namespace UIService
{
    public class UIBlackWindow : UIWindow
    {
        private const float Duration = 1f;
        [SerializeField] private CanvasGroup BlackImage;
        private Tween _showAnimation;
        private Tween _hideAnimation;

        public override void Show()
        {
            _showAnimation?.Kill();
            BlackImage.alpha = 0;
            _showAnimation = BlackImage
                .DOFade(1,Duration)
                .OnComplete(() =>
                {
                    OnShowEvent.Invoke(); 
                    
                });
        }

        public override void Hide()
        {
            _showAnimation?.Kill();
            BlackImage.alpha = 1;
            _showAnimation = BlackImage
                .DOFade(0,Duration)
                .OnComplete(() => 
                { 
                    OnHideEvent.Invoke();
                });
        }
    }
}