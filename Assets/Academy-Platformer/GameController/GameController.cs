using Academy_Platformer.ScoreCounter;
using Academy_Platformer.SoundMVC;
using FactoryPlayer;
using UIService;

public class GameController
{
    private FallObjectSpawner _spawner;
    private InputController _inputController;
    private PlayerController _playerController;
    private UIService.UIService _uiService;
    private UIMainMenuController _mainMenuWindowContrroler;
    private UIGameWindowController _gameWindowController;
    private UIEndGameWindowController _endMenuWindowController;
    private HUDWindowController _hudWindowController ;
    private ScoreCounter _scoreCounter;
    
    public GameController()
    {
        UIInit();
        ScoreInit();    
        
        new SoundController();

        _spawner = new FallObjectSpawner(-7,7,1f, 5f);
        _inputController = new InputController();
        _playerController = new PlayerController(_inputController);
    }
    
    private void UIInit()
    {
        _uiService = new UIService.UIService();
            
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
        TickableManager.UpdateNotify += Update;
    }

    private void StopGame()
    {
        _playerController.DestroyView();
        _spawner.Pool.AllReturnToPool();
        TickableManager.UpdateNotify -= Update;
    }

    private void Update()
    {
        _spawner.Update();
    }
}
