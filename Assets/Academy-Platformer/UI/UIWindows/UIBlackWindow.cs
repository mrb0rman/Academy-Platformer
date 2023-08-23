using Academy_Platformer.UI.UIService;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UIService
{
    public class UIBlackWindow : UIWindow
    {
        [SerializeField] private Image blackImage;
        
        private const float Duration = 1f;

        private Tween _showAnimation;
        private Tween _hideAnimation;

        public override void Show()
        {
            _showAnimation?.Kill();
            var blackImageColor = blackImage.color;
            blackImageColor.a = 0;
            blackImage.color = blackImageColor;
            _showAnimation = transform.DOMoveY(0, 0);
            _showAnimation = blackImage.DOFade(1,Duration)
                .OnComplete(() =>
                {
                    OnShowEvent.Invoke();
                });
        }

        public override void Hide()
        {
            _showAnimation?.Kill();
            _hideAnimation = blackImage
                .DOFade(0,Duration)
                .OnComplete(() => 
                { 
                    OnHideEvent.Invoke();
                });
        }
    }
}