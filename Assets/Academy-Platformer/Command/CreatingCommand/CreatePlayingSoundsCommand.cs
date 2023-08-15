using UnityEngine;

namespace CreatingCommand
{
    public class CreatePlayingSoundsCommand: Command.Command
    {
        private readonly PlayingSounds _playingSoundsPrefab;
        private PlayingSounds _playingSounds;
        
        public CreatePlayingSoundsCommand()
        {
            _playingSoundsPrefab = Resources.Load<PlayingSounds>(ResourcesConst.ResourcesConst.PlayingSounds);
        }
        public override void Execute()
        {
            _playingSounds = Object.Instantiate(_playingSoundsPrefab);
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_playingSounds);
        }
    }
}