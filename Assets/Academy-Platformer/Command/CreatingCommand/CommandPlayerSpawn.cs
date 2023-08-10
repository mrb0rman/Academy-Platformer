using FactoryPlayer;

namespace CreatingCommand
{
    public class CommandPlayerSpawn : Command.Command
    {
        private PlayerController _playerController;
        private PlayerStorage _playerStorage;
        private PlayerView _playerView;

        public CommandPlayerSpawn(PlayerController playerController, PlayerStorage playerStorage)
        {
            _playerController = playerController;
            _playerStorage = playerStorage;
        }
        
        public override void Execute()
        {
            _playerView = _playerController.Spawn();
            _playerStorage.Add(_playerView);
            base.Execute();
        }

        public override void Undo()
        {
            _playerStorage.Delete(_playerView);
        }
    }
}