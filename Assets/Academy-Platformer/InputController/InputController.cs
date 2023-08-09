using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scenes
{
    public class InputController
    {
        private EventManager _eventManager;
        
        public event Action OnLeftEvent;
        public event Action OnRightEvent;
        
        private KeyCode moveLeft = KeyCode.LeftArrow;
        private KeyCode moveRight = KeyCode.RightArrow;
        
        public InputController(EventManager eventManager)
        {
            _eventManager = eventManager;
            _eventManager.UpdateEventHandler += CheckInput;
        }
        
        private void CheckInput()
        {
            if (Input.GetKeyDown(moveLeft))
                OnLeftEvent?.Invoke();
            if (Input.GetKeyDown(moveRight))
                OnRightEvent?.Invoke();
        }
    }
}