using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UIServiceNamespace
{
    public class UIService : IUIService
    {
        private UIRoot _uiRoot;
        private Dictionary<Type, UIWindow> _loadedWindows = new Dictionary<Type, UIWindow>();

        public UIService(UIRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }
    
        public void Init(string path)
        {
            foreach (UIWindow uiWindow in Resources.LoadAll<UIWindow>(path))
            {
                var newWindow = GameObject.Instantiate(uiWindow.gameObject, _uiRoot.deactivateContainer);
                var key = uiWindow.GetType();
                _loadedWindows.Add(key, uiWindow);
            }
        }

        public void Hide<T>() where T : UIWindow
        {
            var window = _loadedWindows[typeof(T)];
            if (window != null)
            {
                window.gameObject.transform.SetParent(_uiRoot.deactivateContainer);
            }
            else
            {
                throw new Exception($"Window of type {typeof(T)} was not found");
            }
        }

        public void Show<T>() where T : UIWindow
        {
            var window = _loadedWindows[typeof(T)];
            if (window != null)
            {
                window.gameObject.transform.SetParent(_uiRoot.activateContainer);
            }
            else
            {
                throw new Exception($"Window of type {typeof(T)} was not found");
            }
        }
    }
}
