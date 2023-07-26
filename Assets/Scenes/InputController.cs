using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public class InputController: MonoBehaviour, iObservable
    {
        private List<IObserver> Observers { get; set; }
        public void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }
        }
        private void Start()
        {
            Observer observer = new Observer();
          //  AddObservers(observer);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NotifyObservers();
            }
        }

        public void InputContoller()
        {
            Observers = new List<IObserver>();
        }

        public void AddObservers(IObserver observer)
        {
        Observers.Add(observer);
        }

        public void RemoveObservers(IObserver observer)
        {
            
        }

       
    }
}