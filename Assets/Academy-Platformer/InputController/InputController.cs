using UnityEngine;
using UnityEngine.Events;

namespace Scenes
{
    public class InputController: MonoBehaviour
    {
        public UnityEvent OnLeftEvent;
        public UnityEvent OnRightEvent;
        
        [SerializeField] private KeyCode moveLeft;
        [SerializeField] private KeyCode moveRight;
        
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