using Academy_Platformer.ScoreCounter;
using Academy_Platformer.SoundMVC;
using FactoryPlayer;
using UIService;
using UnityEngine;

public class GameController
{
    private readonly Camera _camera;
    
    private FallObjectSpawner _spawner;
    private InputController _inputController;
    private PlayerController _playerController;
    private UIService.UIService _uiService;
    private UIMainMenuController _mainMenuWindowContrroler;
    private UIGameWindowController _gameWindowController;
    private UIEndGameWindowController _endMenuWindowController;
    private HUDWindowController _hudWindowController ;
    private ScoreCounter _scoreCounter;
    private SoundController _soundController;
    
    public GameController(Camera camera)
    {
        _camera = camera;
        UIInit();
        ScoreInit();    
        
        _soundController = new SoundController();
        _spawner = new FallObjectSpawner(-7,7,1f, 5f);
        _inputController = new InputController();
        _playerController = new PlayerController(_inputController, _hudWindowController, _camera);
    }
    
    private void UIInit()
    {
        _uiService = new UIService.UIService(_camera);
            
        _mainMenuWindowContrroler = new UIMainMenuController(_uiService, this);
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
        TickableManager.UpdateNotify += Update;
    }

    public void StopGame()
    {
        _playerController.DestroyView();
        _spawner.StopSpawn();
        TickableManager.UpdateNotify -= Update;
    }

    private void Update()
    { }
}
