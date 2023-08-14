using System.Collections;
using System.Collections.Generic;
using FactoryPlayer;
using UnityEngine;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;

    private TickableManager _tickableManager;
    
    public GameController(
        FallObjectSpawner spawner,
        PlayerController playerController,
        TickableManager tickableManager)
    {
        _spawner = spawner;
        _playerController = playerController;
        _tickableManager = tickableManager;
    }

    public void StartGame()
    {
        _playerController.Spawn();
        _tickableManager.UpdateEventHandler += Update;
    }

    public void StopGame()
    {
        _playerController.DestroyView();
        _spawner.Pool.AllReturnToPool();
        _tickableManager.UpdateEventHandler -= Update;
    }
    
    void Update()
    {
        _spawner.Update();
    }
}
