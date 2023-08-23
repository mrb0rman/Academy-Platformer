using Academy_Platformer.UI.HUD;

namespace UIService
{
    public class UIGameWindowController
    {
        private readonly Academy_Platformer.UI.UIService.UIService _uiService;
        private UIGameWindow _GameWindow;

        public UIGameWindowController(Academy_Platformer.UI.UIService.UIService uiService)
        {
            _uiService = uiService;
            _GameWindow = uiService.Get<UIGameWindow>();
        }

        public void ShowEndMenuWindow()
        {
            _uiService.Hide<UIGameWindow>();
            _uiService.Hide<HUDWindow>();
            _uiService.Show<UIEndGameWindow>();
        }
    }
}