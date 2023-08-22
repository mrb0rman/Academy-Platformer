using Academy_Platformer.ScoreCounter;
using Academy_Platformer.SoundMVC;
using FactoryPlayer;
using UIService;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;
    private InputController _inputController;

    private UIService.UIService _uiService;
    private HUDWindowController _hudWindowController;

    private SoundController _soundController;

    private ScoreCounter _scoreCounter;

    public GameController()
    {
        _uiService = new UIService.UIService();

        CreateUIWindowControllers();

        _inputController = new InputController();
        _soundController = new SoundController();
        _scoreCounter = new ScoreCounter();

        _playerController = new PlayerController(_inputController, _hudWindowController);
    }

    private void CreateUIWindowControllers()
    {
        var mainMenuController = new UIMainMenuController(_uiService);
        var gameWindowController = new UIGameWindowController(_uiService);
        var endGameWindowController = new UIEndGameWindowController(_uiService);
        _hudWindowController = new HUDWindowController(_uiService);
    }

    public void InitGame()
    {
        _uiService.Show<UIMainMenuWindow>();

        _scoreCounter.ScoreChangeNotify += _hudWindowController.ChangeScore;
    }

    public void StartGame()
    {
        _playerController.Spawn();
        TickableManager.UpdateNotify += Update;
    }

    public void StopGame()
    {
        _playerController.DestroyView();
        _spawner.Pool.AllReturnToPool();
        TickableManager.UpdateNotify -= Update;
    }
    
    void Update()
    {
        _spawner.Update();
    }
}
