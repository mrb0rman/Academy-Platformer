namespace UIService
{
    public class UIGameWindowController
    {
        private UIGameWindow _gameWindowView;
        
        public UIGameWindowController(UIGameWindow view)
        {
            _gameWindowView = view;
        }

        public void CloseWindow()
        {
            _gameWindowView.Hide();
            _gameWindowView.uiService.Hide<UIGameWindow>();
        }
    }
}