using UnityEngine.PlayerLoop;

namespace UIServiceNamespace
{
    public interface IUIService
    {
        void Init(string path);
        void Hide<T>() where T : UIWindow;
        void Show<T>() where T : UIWindow;
    }
}