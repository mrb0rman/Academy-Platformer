using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UIService
{
    public class UIBlackWindow : UIWindow
    {
        [SerializeField] private Image BlackImage;
        
        private const float duration = 1f;
        
        private Tween _showAnimation;
        private Tween _hideAnimation;

        public override void Show()
        {
            _showAnimation?.Kill();
            var blackImageColor = BlackImage.color;
            blackImageColor.a = 0;
            BlackImage.color = blackImageColor;
            _showAnimation = BlackImage
                .DOFade(1,duration)
                .OnComplete(() =>
                {
                    OnShowEvent.Invoke();
                });
        }

        public override void Hide()
        {
            _showAnimation?.Kill();
            var blackImageColor = BlackImage.color;
            blackImageColor.a = 1;
            BlackImage.color = blackImageColor;
            _showAnimation = BlackImage
                .DOFade(0,duration)
                .OnComplete(() => 
                { 
                    OnHideEvent.Invoke();
                });
        }
    }
}