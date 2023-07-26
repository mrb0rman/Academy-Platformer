using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using UnityEngine;

public class UIService : IUIService
{
    private UIRoot _uiRoot;
    private Dictionary<Type, UIWindow> _loadedWindows;

    public UIService(UIRoot uiRoot)
    {
        _loadedWindows = new Dictionary<Type, UIWindow>();
        _uiRoot = uiRoot;
    }
    
    public void Init()
    {
        foreach (UIWindow uiWindow in Resources.LoadAll<UIWindow>(""))
        {
            GameObject newWindow = GameObject.Instantiate(uiWindow.gameObject, _uiRoot.deactivateContainer);
            Type key = uiWindow.GetType();
            _loadedWindows.Add(key, uiWindow);
        }
    }

    public void Hide<T>() where T : UIWindow
    {
        UIWindow window = _loadedWindows[typeof(T)];
        if (window != null)
        {
            window.gameObject.transform.SetParent(_uiRoot.deactivateContainer);
        }
    }

    public void Show<T>() where T : UIWindow
    {
        UIWindow window = _loadedWindows[typeof(T)];
        if (window != null)
        {
            window.gameObject.transform.SetParent(_uiRoot.activateContainer);
        }
    }
}
