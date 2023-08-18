using System;

namespace UIService
{
    public class UIGameWindow : UIAnimationWindow
    {
        public Action OpenGameWindowEvent;
        public GameController GameController;
        public override void Show()
        {
            base.Show();
            UIService.Show<HUDWindow>();
            GameController.StartGame();
        }

        public override void Hide()
        {
            base.Hide();
            GameController.StopGame();
        }
    }
}