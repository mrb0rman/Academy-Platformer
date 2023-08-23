using FactoryPlayer;
using UIService;

public class GameController
{
    private FallObjectSpawner _spawner;

    private readonly PlayerController _playerController;
    private readonly InputController _inputController;
    private readonly UIGameWindow  _gameWindow;

    public GameController(UIService.UIService uiService)
    {
        _inputController = new InputController();
        _playerController =  new PlayerController(_inputController);
        _spawner = new FallObjectSpawner();

        _gameWindow.OnShowEvent += StartGame;
        _gameWindow.OnHideEvent += StopGame;
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
    
    void Update()
    {
    }

    ~GameController()
    {
        _gameWindow.OnShowEvent -= StartGame;
        _gameWindow.OnHideEvent -= StopGame;
    }
}
