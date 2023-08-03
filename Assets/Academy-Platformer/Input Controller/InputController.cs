using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scenes
{
    public class InputController: MonoBehaviour
    {
        [SerializeField] private KeyCode moveLeft;
        [SerializeField] private KeyCode moveRight;
        
        public UnityEvent OnLeftEvent;
        public UnityEvent OnRightEvent;
        
        
        private void Update()
        {
            if (Input.GetKeyDown(moveLeft))
            {
                OnLeftEvent.Invoke();
            }
            if (Input.GetKeyDown(moveRight))
            {
                OnRightEvent.Invoke();
            }

        }
        
    }
}