using Academy.Platformer.Player;
using UnityEngine;

namespace CreatingCommand
{
    public class CreatePlayerMovementCommand : Command.Command
    {
        private readonly PlayerMovementCreator _playerMovementCreatorPrefab;
        private PlayerMovementCreator _playerMovementCreator;

        public CreatePlayerMovementCommand()
        {
            _playerMovementCreatorPrefab = Resources.Load<PlayerMovementCreator>(
                ResourcesConst.ResourcesConst.PlayerMovementCreator);
        }
        public override void Execute()
        {
            _playerMovementCreator = Object.Instantiate(_playerMovementCreatorPrefab);
            base.Execute();
        }
    
        public override void Undo()
        {
            Object.Destroy(_playerMovementCreator);
        }
    }
}