using Academy_Platformer.ScoreCounter;
using Academy_Platformer.SoundMVC;
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
        private PlayerController _playerController;
        private ScoreCounter _scoreCounter;

        private void Start()
        {
            StartBootstrap();
        }
        
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateTickableManagerCommand());
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _uiService = new UIService.UIService();
            var mainMenuWindowController = new UIMainMenuController(_uiService);
            var gameWindowController = new UIGameWindowController(_uiService);
            var endMenuWindowController = new UIEndGameWindowController(_uiService);
            var hudWindowController = new HUDWindowController(_uiService);
            _uiService.Show<UIMainMenuWindow>();
            
            _inputController = new InputController();
            _playerController = new PlayerController(_inputController, hudWindowController);

            new PlayerController(_inputController);
            new SoundController();
            
            _scoreCounter = new ScoreCounter();
            _scoreCounter.ScoreChangeNotify += hudWindowController.ChangeScore;
        }

        private void NotifyOfCompletion()
        { }
    }
}