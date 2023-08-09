using System;
using UIService;
using UnityEngine;
using UnityEngine.Events;

namespace Academy_Platformer.UI.UIWindows.NewLogic
{
    public class UIMainMenuWindow : UIAnimationWindow
    {
        public Action OnStartButtonClickEvent;
        [SerializeField] private UIButton.UIButton startButton;
        public override void Show()
        {
            base.Show();
            startButton.OnClickButton += Method;
        }

        public override void Hide()
        {
            base.Hide();
            startButton.OnClickButton -= Method;
        }

        private void Method()
        {
            OnStartButtonClickEvent.Invoke();
        }
    }
}