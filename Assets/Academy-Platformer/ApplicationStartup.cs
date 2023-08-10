using Bootstrap;
using Command;
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
            Create<TickableManager>(ResourcesConst.ResourcesConst.TickableManager);
        }
        
        private T Create<T>(string resourcesConst) where T: Object
        {
            var prefab = Resources.Load<T>(resourcesConst);
            var obj = Instantiate(prefab);
            return obj; 
        }

        private void StartBootstrap()
        {
            _bootstrap.Add(new CommandPlayerSpawn(_playerController, _playerStorage));
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        { }
    }
}