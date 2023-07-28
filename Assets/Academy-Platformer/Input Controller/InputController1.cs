using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public delegate void Handler(KeyCode code);
    public class InputController: MonoBehaviour
    {
        [SerializeField] private KeyCode MoveLeft;
        [SerializeField] private KeyCode MoveRight;
        
        public static event Handler OnMove;

        private void Update()
        {
            if (Input.GetKeyDown(MoveLeft))
            {
                OnMove += MovePlatform;
            }
            else
            {
                OnMove -= MovePlatform;
            }
            if (Input.GetKeyDown(MoveRight))
            {
                OnMove += MovePlatform;
            }
            else
            {
                OnMove -= MovePlatform;
            }
        }

        public void MovePlatform(KeyCode code)
        {
            
        }
    }
}