using System;
using FactoryPlayer;
using UIService;
using UnityEngine;

public class GameController
{
    private FallObjectSpawner _spawner;

    private PlayerController _playerController;

    public GameController(UIGameWindow gameWindow,
        PlayerController playerController)
    {
        _spawner = new FallObjectSpawner();
        _playerController = playerController;
        gameWindow.OpenGameWindowEvent += StartGame;
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
