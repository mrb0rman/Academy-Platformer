using System.Collections;
using System.Collections.Generic;
using FactoryPlayer;
using UnityEngine;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;

    private PlayerView _playerView;
    
    public GameController(FallObjectSpawner spawner,
        PlayerController playerController)
    {
        _spawner = spawner;
        _playerController = playerController;
    }

    public void StartGame()
    {
        _playerView = _playerController.Spawn();
        TickableManager.UpdateEventHandler += Update;
    }

    public void StopGame()
    {
        GameObject.Destroy(_playerView.gameObject);
        TickableManager.UpdateEventHandler -= Update;
    }
    
    void Update()
    {
        _spawner.Update();
    }
}
