using UnityEngine;
using UnityEngine.Events;

namespace Scenes
{
    public partial class InputController: MonoBehaviour
    {
        public UnityEvent OnLeftEvent;
        public UnityEvent OnRightEvent;
        
        [SerializeField] private KeyCode moveLeft;
        [SerializeField] private KeyCode moveRight;

        private void OnEnable()
        {
            EventManager.UpdateEventHandler += CheckInput;
        }
        private void OnDisable()
        {
            EventManager.UpdateEventHandler -= CheckInput;
        }
        
        private void CheckInput()
        {
            if (Input.GetKeyDown(moveLeft))
                OnLeftEvent.Invoke();
            if (Input.GetKeyDown(moveRight))
                OnRightEvent.Invoke();
        }
    }
}