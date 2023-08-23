using Academy_Platformer.FallObject;
using Academy_Platformer.Player;
using Academy_Platformer.Sounds;
using Academy_Platformer.UI.HUD;
using UIService;

namespace Academy_Platformer
{
    public class GameController
    {
        private readonly UnityEngine.Camera _camera;
    
        private FallObjectSpawner _spawner;
        private InputController _inputController;
        private PlayerController _playerController;
        private UI.UIService.UIService _uiService;
        private UIMainMenuController _mainMenuWindowContrroler;
        private UIGameWindowController _gameWindowController;
        private UIEndGameWindowController _endMenuWindowController;
        private HUDWindowController _hudWindowController ;
        private ScoreCounter _scoreCounter;
    
        public GameController(UnityEngine.Camera camera)
        {
            _camera = camera;
            UIInit();
            ScoreInit();    
        
            new SoundController();

            _spawner = new FallObjectSpawner(-7,7,1f, 5f);
            _inputController = new InputController();
            _playerController = new PlayerController(_inputController);
        }
    
        private void UIInit()
        {
            _uiService = new UI.UIService.UIService(_camera);
            
            _mainMenuWindowContrroler = new UIMainMenuController(_uiService);
            _gameWindowController = new UIGameWindowController(_uiService);
            _endMenuWindowController = new UIEndGameWindowController(_uiService);
            _hudWindowController = new HUDWindowController(_uiService);
        }

        private void ScoreInit()
        {
            _scoreCounter = new ScoreCounter();
            _scoreCounter.ScoreChangeNotify += _hudWindowController.ChangeScore;
        }

        public void InitGame()
        {
            _uiService
                .Get<UIMainMenuWindow>()
                .OnStartButtonClickEvent += () =>
            {
                StartGame();
            };
            _uiService.Show<UIMainMenuWindow>();
        }

        private void StartGame()
        {
            _playerController.Spawn();
            TickableManager.TickableManager.UpdateNotify += Update;
        }

        private void StopGame()
        {
            _playerController.DestroyView();
            _spawner.Pool.AllReturnToPool();
            TickableManager.TickableManager.UpdateNotify -= Update;
        }

        private void Update()
        {
            _spawner.Update();
        }
    }
}
