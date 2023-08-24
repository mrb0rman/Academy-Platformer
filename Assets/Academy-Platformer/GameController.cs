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
        private UIMainMenuController _mainMenuWindowController;
        private UIGameWindowController _gameWindowController;
        private UIEndGameWindowController _endMenuWindowController;
        private HUDWindowController _hudWindowController;
        private ScoreCounter _scoreCounter;
        private SoundController _soundController;

        public GameController(UnityEngine.Camera camera)
        {
            _camera = camera;
            UIInit();
            ScoreInit();    
        
            _soundController = new SoundController();
            _spawner = new FallObjectSpawner(-7,7,1f, 5f);
            _inputController = new InputController();
            _playerController = new PlayerController(_inputController, _hudWindowController);
        }

        private void UIInit()
        {
            _uiService = new Academy_Platformer.UI.UIService.UIService(_camera);
            
            _mainMenuWindowController = new UIMainMenuController(_uiService, this);
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
            _uiService.Show<UIMainMenuWindow>();
        }

        public void StartGame()
        {
            _playerController.Spawn();
            _spawner.StartSpawn();
            TickableManager.TickableManager.UpdateNotify += Update;
        }

        private void StopGame()
        {
            _playerController.DestroyView();
            _spawner.StopSpawn();
            TickableManager.TickableManager.UpdateNotify -= Update;
        }

        private void Update()
        {
            _spawner.Update();
        }
    }
}