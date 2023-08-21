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
        [SerializeField] private float _spawnPeriodMin;
        [SerializeField] private float _spawnPeriodMax;
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        private InputController _inputController;
        private PlayerStorage _playerStorage;
        private ScoreCounter _scoreCounter;
        private HUDWindowController _hudWindowController;

        private void Start()
        {
            StartBootstrap();
        }

        private void StartBootstrap()
        {
            _uiService = new();
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand(ref _hudWindowController));
            _bootstrap.Add(new CreateTickableManagerCommand());
            
            
        


            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _inputController = new InputController();
            _playerController = new PlayerController(_inputController);
            new SoundController();
            
            _scoreCounter = new ScoreCounter();
            _scoreCounter.ScoreChangeNotify += _hudWindowController.ChangeScore;

            
            
            var gameWindow = _uiService.Get<UIGameWindow>();
            var spawner = new FallObjectSpawner(
                _spawnPeriodMin,
                _spawnPeriodMax);
            _gameController = new GameController(
                gameWindow,
                spawner,
                _playerController);
        }

        private void NotifyOfCompletion()
        {
        }
    }
}