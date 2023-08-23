using System;
using Academy_Platformer.UI;
using UnityEngine;

namespace UIService
{
    public class UIMainMenuWindow : UIAnimationWindow
    {
        public Action OnStartButtonClickEvent;
        
        [SerializeField] private UIButton startButton;
        public override void Show()
        {
            base.Show();
            startButton.OnClickButton += StartButtonClickEvent;
        }

        public override void Hide()
        {
            base.Hide();
            startButton.OnClickButton -= StartButtonClickEvent;
        }

        private void StartButtonClickEvent()
        {
            OnStartButtonClickEvent.Invoke();
        }
    }
}