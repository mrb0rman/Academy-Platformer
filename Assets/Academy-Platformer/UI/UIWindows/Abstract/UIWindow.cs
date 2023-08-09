using UnityEngine;
using UnityEngine.Events;

namespace UIService
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        [HideInInspector] public UnityEvent OnShowEvent;        
        [HideInInspector] public UnityEvent OnHideEvent;  
        
        public IUIService UIService { get; set; }
        
        public abstract void Show();
        public abstract void Hide();
    }
}