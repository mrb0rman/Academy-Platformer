using Bootstrap;
using CreatingCommand;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();

        private void Start()
        {
            StartBootstrap();
            
            var gameController = new GameController();
            gameController.InitGame();
        }

        private void StartBootstrap()
        {
            var uiService = new UIService.UIService();
            _bootstrap.Add(new CreateMainCameraCommand());
            _bootstrap.Add(new CreateTickableManagerCommand());

            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        {
        }
    }
}