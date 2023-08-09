using UnityEngine.Events;

namespace Academy_Platformer.UI.UIWindows.NewLogic
{
    public class UIMainMenuController
    {
        private readonly UIService.UIService _uiService;
        
        private UIMainMenuWindow _mainMenuWindow;

        public UIMainMenuController(UIService.UIService uiService)
        {
            _uiService = uiService;

            //ссылка на uiservice
            _mainMenuWindow = uiService.Get<UIMainMenuWindow>();

            _mainMenuWindow.OnStartButtonClickEvent += Method;
        }

        public void Method()
        {
            _uiService.Hide<UIMainMenuWindow>();
            
            //_uiService.Show<UIGameWindow>();
        }
    }
}