namespace Scenes
{
    public interface iObservable
    {
        void AddObservers(IObserver observer);
        void RemoveObservers(IObserver observer);
        void NotifyObservers();
    }
}