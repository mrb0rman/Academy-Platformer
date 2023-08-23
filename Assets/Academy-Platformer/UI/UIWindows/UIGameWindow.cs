using System;
using Academy_Platformer.UI.HUD;

namespace UIService
{
    public class UIGameWindow : UIAnimationWindow
    {
        public Action OpenGameWindowEvent;
        public override void Show()
        {
            base.Show();
            UIService.Show<HUDWindow>();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}