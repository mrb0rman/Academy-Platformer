using FactoryPlayer;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;

    public GameController(
        FallObjectSpawner spawner,
        PlayerController playerController)
    {
        _spawner = spawner;
        _playerController = playerController;
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
