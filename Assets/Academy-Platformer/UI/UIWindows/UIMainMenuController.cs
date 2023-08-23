namespace UIService
{
    public class UIMainMenuController
    {
        private readonly Academy_Platformer.UI.UIService.UIService _uiService;
        
        private UIMainMenuWindow _mainMenuWindow;

        public UIMainMenuController(Academy_Platformer.UI.UIService.UIService uiService)
        {
            _uiService = uiService;
            _mainMenuWindow = uiService.Get<UIMainMenuWindow>();
            
            _mainMenuWindow.OnShowEvent += ShowWindow;
            _mainMenuWindow.OnHideEvent += HideWindow;
        }

        private void ShowWindow()
        {
            _mainMenuWindow.OnStartButtonClickEvent += ShowGameWindow;
        }
        private void HideWindow()
        {
            _mainMenuWindow.OnStartButtonClickEvent -= ShowGameWindow;
        }
        private void ShowGameWindow()
        {
            _uiService.Hide<UIMainMenuWindow>();
            _uiService.Show<UIGameWindow>();
        }
    }
}