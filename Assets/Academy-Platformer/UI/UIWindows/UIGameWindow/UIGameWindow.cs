using System;

namespace UIService
{
    public class UIGameWindow : UIAnimationWindow
    {
        public Action OpenGameWindowEvent;
        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}