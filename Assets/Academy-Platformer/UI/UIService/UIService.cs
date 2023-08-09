using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace UIService
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
            var windows = Resources.LoadAll<UIWindow>(path);
            if (windows.Length > 0)
            {
                foreach (var uiWindow in windows)
                {
                    var newWindow = GameObject.Instantiate(uiWindow, _uiRoot.DeactivateContainer, false);
                    newWindow.uiService = this;
                    var key = newWindow.GetType();
                    _loadedWindows.Add(key, newWindow);
                }
            }
        }

        public void Hide<T>() where T : UIWindow
        {
            if (_loadedWindows.TryGetValue(typeof(T), out UIWindow value))
            {
                value.gameObject.transform.SetParent(_uiRoot.DeactivateContainer);
                //value.Hide();
            }
            else
            {
                Debug.LogError($"Window of type {typeof(T)} was not found");
            }
        }

        public void Show<T>() where T : UIWindow
        {
            if (_loadedWindows.TryGetValue(typeof(T), out UIWindow value))
            { 
                value.gameObject.transform.SetParent(_uiRoot.ActivateContainer);
                //value.Show();
            }
            else
            {
                Debug.LogError($"Window of type {typeof(T)} was not found");
            }
        }
    }
}
