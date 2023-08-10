using System;
using FactoryPlayer;

namespace Command
{
    public class CommandPlayerSpawn : Command
    {
        public override event Action OnCommandExecuteNotify;

        private PlayerController _playerController;
        private PlayerStorage _playerStorage;

        public CommandPlayerSpawn(PlayerController playerController, PlayerStorage playerStorage)
        {
            _playerController = playerController;
            _playerStorage = playerStorage;
        }
        
        public override void Execute()
        {
            _playerStorage.Add(_playerController.Spawn());
            
            OnCommandExecuteNotify?.Invoke();
        }

        public override void Undo()
        { }
    }
}