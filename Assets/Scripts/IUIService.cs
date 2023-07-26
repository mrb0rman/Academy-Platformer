using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public interface IUIService
    {
        void Init();

        void Hide<T>() where T : UIWindow;
        
        void Show<T>() where T : UIWindow;
    }
}