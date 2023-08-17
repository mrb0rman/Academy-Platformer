using FactoryPlayer;
using UnityEngine;

public class GameController
{
    private FallObjectSpawner _spawner;
    private Transform[] spawnPoints = new Transform[2];
    private InputController _inputController;
    private PlayerController _playerController;

    public GameController()
    {
        CreateSpawnPoints();
        _spawner = new FallObjectSpawner(spawnPoints, 1f, 5f);
        _inputController = new InputController();
        _playerController = new PlayerController(_inputController);

        StartGame();
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

    private void CreateSpawnPoints()
    {
        GameObject spawnPoint1 = new GameObject("spawnPoint1");
        var spawnTransform = spawnPoint1.transform.position;
        spawnTransform.x = 120;
        spawnPoint1.transform.position = spawnTransform;
        spawnPoints[0] = spawnPoint1.transform;
        
        GameObject spawnPoint2 = new GameObject("spawnPoint2");
        spawnPoints[1] = spawnPoint2.transform;
    }
    
    void Update()
    {
        _spawner.Update();
    }
}
