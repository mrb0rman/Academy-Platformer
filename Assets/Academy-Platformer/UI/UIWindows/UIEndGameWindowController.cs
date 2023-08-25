namespace UI.UIWindows
{
    public class UIEndGameWindowController
    {
        private readonly UIService.UIService _uiService;
        private UIEndGameWindow _endGameWindow;
        public UIEndGameWindowController(UIService.UIService uiService)
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