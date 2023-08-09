namespace UIService
{
    public class UIMainMenuWindowController
    {
        private UIMainMenuWindow _mainMenuWindowView;
        
        public UIMainMenuWindowController(UIMainMenuWindow view)
        {
            _mainMenuWindowView = view;
            OpenNextWindowButton();
        }

        private void OpenNextWindowButton()
        {
            _mainMenuWindowView.playButton.OnClickButton += _mainMenuWindowView.Hide; //анимация
            _mainMenuWindowView.playButton.OnClickButton+= _mainMenuWindowView.uiService.Hide<UIMainMenuWindow>; //контейнер
            
            _mainMenuWindowView.playButton.OnClickButton+= _mainMenuWindowView.uiService.Show<UIGameWindow>;
        }
    }
}