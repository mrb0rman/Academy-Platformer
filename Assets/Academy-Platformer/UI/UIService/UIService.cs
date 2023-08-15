using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UIService
{
       public class UIService : IUIService
    {
        private Transform _deactivatedContainer;
        
        private readonly UIRoot _uIRoot;
        private readonly Dictionary<Type,UIWindow> _viewStorage = new Dictionary<Type,UIWindow>();
        private readonly Dictionary<Type, GameObject> _initWindows= new Dictionary<Type, GameObject>();

        private const string UISource = "";
        
        public UIService()
        {
            _uIRoot = Resources.Load<UIRoot>("UIRoot");
            _uIRoot = Object.Instantiate<UIRoot>(_uIRoot);

            LoadWindows(UISource);
            InitWindows(_uIRoot.PoolContainer);
        }

        public T Show<T>() where T : UIWindow
        {
            var window = Get<T>();
            if(window != null)
            {
                Transform transform;
                (transform = window.transform).SetParent(_uIRoot.Container, false);

                Vector3 scale = window.transform.localScale;
                scale.Set(1, 1, 1);
                window.transform.localScale = scale;
                
                transform.localRotation = Quaternion.identity;
                transform.localPosition = new Vector3(-_uIRoot.Container.localPosition.x,-_uIRoot.Container.localPosition.y * 3,0);
                
                var component = window.GetComponent<T>();
                component.Show();
                return component;
            }
            return null;
        }
        
        public T Get<T>() where T : UIWindow
        {
            var type = typeof(T);
            if (_initWindows.ContainsKey(type))
            {
                var view = _initWindows[type];            
                return view.GetComponent<T>();
            }
            return null;
        }

        public void Hide<T>(Action onEnd = null) where T : UIWindow
        {
            var window = Get<T>();
            
            if(window!=null)
            {
                Action changeParent = () => window.transform.SetParent(_uIRoot.PoolContainer);
                window.OnHideEvent += changeParent;
                window.Hide();
                
                onEnd?.Invoke();
            }
        }

        public void InitWindows(Transform poolDeactiveContiner)
        {
            _deactivatedContainer = poolDeactiveContiner == null ? _uIRoot.PoolContainer : poolDeactiveContiner;
            foreach (var windowKVP in _viewStorage)
            {
                Init(windowKVP.Key, _deactivatedContainer);
            }
        }

        public void LoadWindows(string source)
        {
            var windows = Resources.LoadAll(source, typeof(UIWindow));

            foreach (var window in windows)
            {
                var windowType = window.GetType();

                _viewStorage.Add(windowType, (UIWindow)window);
            }
        }

        private void Init(Type t, Transform parent = null)
        {
            if(_viewStorage.ContainsKey(t))
            {
                GameObject view = null;
                if(parent!=null)
                {
                    view = Object.Instantiate(_viewStorage[t].gameObject, parent);
                }
                else
                {
                    view = Object.Instantiate(_viewStorage[t].gameObject);
                }

                var uiWindow = view.GetComponent<UIWindow>();
                uiWindow.UIService = this;
                
                _initWindows.Add(t, view);
            }
            var blackWindow = Get<UIBlackWindow>();
            blackWindow.transform.SetParent(new RectTransform());
        }
    }
}
