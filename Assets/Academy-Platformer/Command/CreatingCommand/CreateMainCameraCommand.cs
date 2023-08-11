using UnityEngine;
using Object = UnityEngine.Object;


namespace CreatingCommand
{
    public class CreateMainCameraCommand : Command.Command
    {
        private readonly Camera _mainCameraPrefab;
        private Camera _mainCamera;

        public CreateMainCameraCommand()
        {
            _mainCameraPrefab = Resources.Load<Camera>(ResourcesConst.ResourcesConst.MainCamera);
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

