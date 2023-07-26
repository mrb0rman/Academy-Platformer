using UnityEngine;

namespace Scenes
{
    public class Observer : IObserver
    {
        public void Update(iObservable observable)
        {
            Debug.Log("001");
        }
    }
}