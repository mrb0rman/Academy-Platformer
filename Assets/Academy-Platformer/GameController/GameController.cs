using System;
using FactoryPlayer;
using UIService;
using UnityEngine;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;

    public GameController(UIGameWindow gameWindow,
        FallObjectSpawner spawner,
        PlayerController playerController)
    {
        gameWindow.OpenGameWindowEvent += StartGame;
        _spawner = spawner;
        _playerController = playerController;
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
}
