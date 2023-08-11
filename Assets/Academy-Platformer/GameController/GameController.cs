using System.Collections;
using System.Collections.Generic;
using FactoryPlayer;
using UnityEngine;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;
    
    public GameController(FallObjectSpawner spawner,
        PlayerController playerController)
    {
        _spawner = spawner;
        _playerController = playerController;
        _playerController.Spawn();
        TickableManager.UpdateEventHandler += Update;
    }
    
    void Update()
    {
        _spawner.Update();
    }
}
