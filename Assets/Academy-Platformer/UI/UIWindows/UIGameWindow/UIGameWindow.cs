using System;
using UnityEngine;

namespace UIService
{
    public class UIGameWindow : UIAnimationWindow
    {
        public Action OpenGameWindowEvent;
        public override void Show()
        {
            OpenGameWindowEvent?.Invoke();
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}