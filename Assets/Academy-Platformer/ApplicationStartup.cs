using Bootstrap;
using CreatingCommand;
using FactoryPlayer;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();

        private TickableManager _tickableManager;
        private InputController _inputController;
        private PlayerController _playerController;
        private PlayerStorage _playerStorage;

        private void Start()
        {
            CreateTickableManager();
            _inputController = new InputController(_tickableManager);
            StartBootstrap();
        }

        private void CreateTickableManager()
        {
            var tickableManagerPrefab = Resources.Load<TickableManager>(
                ResourcesConst.ResourcesConst.TickableManager);
            _tickableManager = Instantiate(tickableManagerPrefab);
        }
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateUICommand());
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _playerController = new PlayerController(_inputController);
        }

        private void NotifyOfCompletion()
        { }
    }
}