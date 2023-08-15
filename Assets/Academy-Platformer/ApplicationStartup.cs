﻿using Bootstrap;
using CreatingCommand;
using FactoryPlayer;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        private InputController _inputController;
        private PlayerStorage _playerStorage;

        private void Start()
        {
            StartBootstrap();
        }
        
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand());
            _bootstrap.Add(new CreateTickableManagerCommand());
            _bootstrap.Add(new CreatePlayingSoundsCommand());
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _inputController = new InputController();
            
            new PlayerController(_inputController);
        }

        private void NotifyOfCompletion()
        { }
    }
}