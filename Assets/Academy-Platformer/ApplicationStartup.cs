using Bootstrap;
using CreatingCommand;
using FactoryPlayer;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        private PlayerController _playerController;
        private PlayerStorage _playerStorage;
        
        private void Start()
        {
           
            StartBootstrap();
        }
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateTickableManagerCommand());
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand());

            _playerStorage = new PlayerStorage();
            _playerController = new PlayerController();
            var spawnPlayerCommand = new CommandPlayerSpawn(_playerController, _playerStorage);
            _bootstrap.Add(spawnPlayerCommand);
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        { }
    }
}