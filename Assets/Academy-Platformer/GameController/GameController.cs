using Academy_Platformer.Sounds;
using FactoryPlayer;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;
    private SoundController _soundController;

    public GameController(
        FallObjectSpawner spawner,
        PlayerController playerController,
        TickableManager tickableManager)
    {
        _spawner = spawner;
        _playerController = playerController;

        _soundController = new SoundController();
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