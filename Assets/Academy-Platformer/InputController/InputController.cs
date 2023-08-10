using System;
using UnityEngine;

namespace Scenes
{
    public class InputController
    {
        private TickableManager _tickableManager;
        
        public event Action OnLeftEvent;
        public event Action OnRightEvent;
        
        private KeyCode moveLeft = KeyCode.LeftArrow;
        private KeyCode moveRight = KeyCode.RightArrow;
        
        public InputController(TickableManager tickableManager)
        {
            _tickableManager = tickableManager;
            _tickableManager.UpdateEventHandler += CheckInput;
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