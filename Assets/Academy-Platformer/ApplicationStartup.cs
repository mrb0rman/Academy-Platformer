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
        private ScoreCounter _scoreCounter;
        private HUDWindowController _hudWindowController;
        private GameController _gameController;

        private void Start()
        {
            StartBootstrap();
        }

        private void StartBootstrap()
        {
            var uiService = new UIService.UIService();
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand(uiService ,ref _hudWindowController));
            _bootstrap.Add(new CreateTickableManagerCommand());

            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _inputController = new InputController();
            var playerController = new PlayerController(_inputController);
            new SoundController();
            
            _scoreCounter = new ScoreCounter();
            _scoreCounter.ScoreChangeNotify += _hudWindowController.ChangeScore;
            
            var gameWindow = uiService.Get<UIGameWindow>();
            _gameController = new GameController(
                gameWindow,
                playerController);
        }

        private void NotifyOfCompletion()
        {
        }
    }
}