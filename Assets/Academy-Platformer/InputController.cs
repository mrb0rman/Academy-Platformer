using System;
using UnityEngine;

namespace Academy_Platformer
{
    public class InputController
    {
        public event Action OnLeftEvent;
        public event Action OnRightEvent;

        public InputController()
        {
            TickableManager.TickableManager.UpdateNotify += CheckInput;
        }

        private void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnLeftEvent?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnRightEvent?.Invoke();
            }
        }
    }
}