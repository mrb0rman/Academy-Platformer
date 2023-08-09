using System;
using Bootstrap;
using UIService;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        public UIRoot root;
        public Transform UIParent;

        private void Start()
        {
            StartBootstrap();
            StartUIServer();
            
        }

        private void StartUIServer()
        {
            root = Instantiate(root, UIParent, false);
            var UIWindows = new UIService.UIService(root);
            UIWindows.Init("");
            UIWindows.Show<UIMainMenuWindow>();
            
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