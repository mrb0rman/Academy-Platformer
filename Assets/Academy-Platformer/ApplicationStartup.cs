using Bootstrap;
using UIService;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        
        private void Start()
        {
            StartBootstrap();
            StartUIServer();
        }

        private void StartUIServer()
        {
            var UIService = new UIService.UIService();
            
            var mainMenuWindowContrroler = new UIMainMenuController(UIService);
            var gameWindowController = new UIGameWindowController(UIService);
            var endMenuWindowController = new UIEndGameWindowController(UIService);
            
            UIService.Show<UIMainMenuWindow>();
        }

        private void StartBootstrap()
        {
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        { }
    }
}