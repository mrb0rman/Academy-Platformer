using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace CreatingCommand
{
    public class CreateMainCameraCommand : Command.Command
    {
        private readonly Camera _mainCameraPrefab;
        private Camera _mainCamera;

        public CreateMainCameraCommand(Camera mainCamera)
        {
            _mainCameraPrefab = mainCamera;
        }

        public override void Execute()
        {
            _mainCamera = Object.Instantiate(_mainCameraPrefab);
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_mainCamera);
        }
    }
}

