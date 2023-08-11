using Academy_Platformer.FallObject;
using Academy_Platformer.ScoreCounter;
using UnityEngine;

namespace CreatingCommand
{
    public class CreateScoreCounterCommand: Command.Command
    {
        private FallObjectController _fallObjectController;
        private ScoreCounter _scoreCounter;
        
        public CreateScoreCounterCommand(FallObjectController fallObjectController)
        {
            _fallObjectController = fallObjectController;
        }
        public override void Execute()
        {
            _scoreCounter = Resources.Load<ScoreCounter>(ResourcesConst.ResourcesConst.ScoreCounter);
            _fallObjectController.PlayerCatchFallingObjectNoyify += _scoreCounter.PlayerCatchFallObjectEventHandler;
            Object.Instantiate(_scoreCounter);
            base.Execute();
        }

        public override void Undo()
        {
            _fallObjectController.PlayerCatchFallingObjectNoyify -= _scoreCounter.PlayerCatchFallObjectEventHandler;
            Object.Destroy(_scoreCounter);
        }
    }
}