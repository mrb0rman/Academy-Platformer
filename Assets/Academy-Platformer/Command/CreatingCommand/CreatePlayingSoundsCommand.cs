using UnityEngine;

namespace CreatingCommand
{
    public class CreateSoundManagerCommand: Command.Command
    {
        private readonly SoundManager _soundManagerPrefab;
        private SoundManager _soundManager;
        
        public CreateSoundManagerCommand()
        {
            _soundManagerPrefab = Resources.Load<SoundManager>(ResourcesConst.ResourcesConst.SoundManager);
        }
        public override void Execute()
        {
            _soundManager = Object.Instantiate(_soundManagerPrefab);
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_soundManager);
        }
    }
}