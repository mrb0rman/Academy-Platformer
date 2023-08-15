using System;
using UnityEngine;

namespace FactoryPlayer
{
    public class Test : MonoBehaviour
    {
        public PlayerView PlayerView;
        private PlayerAnimator _playerAnimator;
        
        private void Start()
        {
            _playerAnimator = new PlayerAnimator(PlayerView);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _playerAnimator.Spawn();
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerAnimator.GetDamage();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _playerAnimator.Death();
            }
        }
    }
}