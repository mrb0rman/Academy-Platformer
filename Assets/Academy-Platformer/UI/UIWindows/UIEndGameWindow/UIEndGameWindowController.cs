namespace UIService
{
    public class UIEndGameWindowController
    {
        private readonly UIService _uiService;
        private UIEndGameWindow _endGameWindow;
        public UIEndGameWindowController(UIService uiService)
        {
            _uiService = uiService;
            _endGameWindow = uiService.Get<UIEndGameWindow>();

            _endGameWindow.OnReturnButtonClickEvent += ShowMainMenuWindows;
        }

        public void ShowMainMenuWindows()
        {
            _uiService.Hide<UIEndGameWindow>();
            _uiService.Show<UIMainMenuWindow>();
        }
    }
}