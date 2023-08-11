using Academy.Platformer.Player;
using FactoryPlayer;
using Scenes;

namespace CreatingCommand
{
    public class CommandPlayerSpawn : Command.Command
    {
        private InputController _inputController;
        private PlayerController _playerController;
        private PlayerStorage _playerStorage;
        private PlayerView _playerView;
        private PlayerMovementController _playerMovementController;

        public CommandPlayerSpawn(
            PlayerController playerController,
            PlayerStorage playerStorage,
            InputController inputController)
        {
            _inputController = inputController;
            _playerController = playerController;
            _playerStorage = playerStorage;
        }
        
        public override void Execute()
        {
            _playerView = _playerController.Spawn();
            _playerStorage.Add(_playerView);
            _playerMovementController = new PlayerMovementController(_inputController, _playerView);
            base.Execute();
        }

        public override void Undo()
        {
            _playerStorage.Delete(_playerView);
        }
    }
}