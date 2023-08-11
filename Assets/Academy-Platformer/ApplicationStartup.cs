using System;
using Bootstrap;
using CreatingCommand;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();

        private void Start()
        {
            StartBootstrap();
        }
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateTickableManagerCommand());
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand());
            _bootstrap.Add(new CreatePlayerMovementCommand());

            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        { }
    }
}