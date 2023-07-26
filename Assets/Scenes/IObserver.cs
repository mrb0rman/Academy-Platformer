using Unity.VisualScripting;

namespace Scenes
{
    public interface IObserver
    {
       void Update(iObservable observable);
    }
}