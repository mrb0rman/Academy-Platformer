using FactoryPlayer;

public class GameController
{
    private FallObjectSpawner _spawner;
    private InputController _inputController;
    private PlayerController _playerController;

    public GameController()
    {
        _spawner = new FallObjectSpawner(-7,7,1f, 5f);
        _inputController = new InputController();
        _playerController = new PlayerController(_inputController);
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
