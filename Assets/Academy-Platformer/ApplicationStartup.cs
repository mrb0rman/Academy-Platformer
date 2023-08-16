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
        private Transform[] _spawnPoints;
        private InputController _inputController;
        private PlayerStorage _playerStorage;
        private UIService.UIService _uiService;
        private PlayerController _playerController;

        private void Start()
        {
            StartBootstrap();
        }
        
        private void StartBootstrap()
        {
            _uiService = new();
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand(_uiService));
            _bootstrap.Add(new CreateTickableManagerCommand());
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _inputController = new InputController();
            
            _playerController = new PlayerController(_inputController);

            UIGameWindow gameWindow = _uiService.Get<UIGameWindow>();
            _spawnPoints = gameWindow.SpawnPoints;
            gameWindow.OpenGameWindowEvent += () =>
            {
                var spawner = new FallObjectSpawner(_spawnPoints,
                    _spawnPeriodMin,
                    _spawnPeriodMax);
                var gameController = new GameController(spawner, _playerController);
                gameController.StartGame();
            };
        }
        private void NotifyOfCompletion()
        { }
    }
}