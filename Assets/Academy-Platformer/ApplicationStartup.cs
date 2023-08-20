using Bootstrap;
using CreatingCommand;
using FactoryPlayer;
using UIService;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        private InputController _inputController;
        private PlayerStorage _playerStorage;
        private UIService.UIService _uiService;

        private void Start()
        {
            StartBootstrap();
            CreateUI();
            CreateGameController();
        }
        
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateTickableManagerCommand());
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }
        
        private void CreateUI()
        {
            _uiService = new UIService.UIService();
            
            var mainMenuWindowContrroler = new UIMainMenuController(_uiService);
            var gameWindowController = new UIGameWindowController(_uiService);
            var endMenuWindowController = new UIEndGameWindowController(_uiService);
            var hudWindowController = new HUDWindowController(_uiService);
            
            _uiService.Show<UIMainMenuWindow>();
        }

        private void CreateGameController()
        {
            var mainMenuWindow = _uiService.Get<UIGameWindow>();
            mainMenuWindow.GameController = new GameController();
        }

        private void NotifyOfCompletion()
        { }
    }
}