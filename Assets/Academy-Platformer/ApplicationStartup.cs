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
        private PlayerStorage _playerStorage = new PlayerStorage();
        
        private void Start()
        {
            _playerController = new PlayerController();
            StartBootstrap();
        }
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateTickableManagerCommand());
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand());
            _bootstrap.Add(new CommandPlayerSpawn(_playerController, _playerStorage));
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        { }
    }
}