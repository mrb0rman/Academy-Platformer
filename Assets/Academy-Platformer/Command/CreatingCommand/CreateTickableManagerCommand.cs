using UnityEngine;

namespace CreatingCommand
{
    public class CreateTickableManagerCommand: Command.Command
    {
        private readonly TickableManager _tickableManagerPrefab;
        private TickableManager _tickableManager;
        
        public CreateTickableManagerCommand()
        {
            _tickableManagerPrefab = Resources.Load<TickableManager>(ResourcesConst.ResourcesConst.TickableManager);
        }
        public override void Execute()
        {
            _tickableManager = Object.Instantiate(_tickableManagerPrefab);
            GameObjectStorage.GetInstance().TickableManager = _tickableManager;
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_tickableManager);
        }
    }
}