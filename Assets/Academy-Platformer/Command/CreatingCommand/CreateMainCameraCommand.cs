using UnityEngine;

namespace CreatingCommand
{
    public class CreateMainCameraCommand : Command.Command
    {
        private readonly Camera _mainCameraPrefab;
        private Camera _mainCamera;

        public CreateMainCameraCommand(out Camera camera)
        {
            _mainCameraPrefab = Resources.Load<Camera>(ResourcesConst.ResourcesConst.MainCamera);
            _mainCamera = Object.Instantiate(_mainCameraPrefab);
            camera = _mainCamera;
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_mainCamera);
        }
    }
}

