using System;

namespace UIService
{
    public class UIGameWindow : UIAnimationWindow
    {
        public Action OpenGameWindowEvent;
        private GameController _gameController;
        public override void Show()
        {
            base.Show();
            UIService.Show<HUDWindow>();
            _gameController = new GameController();
            _gameController.StartGame();
        }

        public override void Hide()
        {
            base.Hide();
            _gameController.StopGame();
        }
    }
}