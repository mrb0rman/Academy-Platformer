using System;
using Academy_Platformer.UI.UIWindows.NewLogic;
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
         
            UIService.Show<UIMainMenuWindow>();

            var mainMenuContrroler = new UIMainMenuController(UIService);

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