using System;
using Academy_Platformer.UI;
using UnityEngine;

namespace UIService
{
    public class UIEndGameWindow : UIAnimationWindow
    {
        public Action OnReturnButtonClickEvent;
        
        [SerializeField] private UIButton returnButton;
        public override void Show()
        {
            base.Show();
            returnButton.OnClickButton += StartReturnButtonClickEvent;
        }

        public override void Hide()
        {
            base.Hide();
            returnButton.OnClickButton -= StartReturnButtonClickEvent;
        }

        private void StartReturnButtonClickEvent()
        {
            OnReturnButtonClickEvent.Invoke();
        }
    }
}