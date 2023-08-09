namespace UIService
{
    public class UIMainMenuController
    {
        private readonly UIService _uiService;
        
        private UIMainMenuWindow _mainMenuWindow;

        public UIMainMenuController(UIService uiService)
        {
            _uiService = uiService;
            
            _mainMenuWindow = uiService.Get<UIMainMenuWindow>();


            _mainMenuWindow.OnStartButtonClickEvent += ShowGameWindow;
        }

        public void ShowGameWindow()
        {
            _uiService.Hide<UIMainMenuWindow>();
            _uiService.Show<UIGameWindow>();
        }
    }
}