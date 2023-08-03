using UnityEngine;
using UnityEngine.Events;

namespace Scenes
{
    public class InputController: MonoBehaviour
    {
        public UnityEvent onLeftEvent;
        public UnityEvent onRightEvent;
        [SerializeField] private KeyCode moveLeft;
        [SerializeField] private KeyCode moveRight;
        private void Update()
        {
            if (Input.GetKeyDown(moveLeft))
            {
                onLeftEvent.Invoke();
            }
            if (Input.GetKeyDown(moveRight))
            {
                onRightEvent.Invoke();
            }
        }
    }
}