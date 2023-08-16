using UnityEngine;

namespace CreatingCommand
{
    public class CreateSoundManagerCommand: Command.Command
    {
        private readonly SoundView _soundViewPrefab;
        private SoundView _soundView;
        
        public CreateSoundManagerCommand()
        {
            _soundViewPrefab = Resources.Load<SoundView>(ResourcesConst.ResourcesConst.SoundManager);
        }
        public override void Execute()
        {
            _soundView = Object.Instantiate(_soundViewPrefab);
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_soundView);
        }
    }
}