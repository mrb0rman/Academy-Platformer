using System;
using UnityEngine;

namespace FactoryPlayer
{
    public class Test : MonoBehaviour
    {
        private PlayerController _playerController;
        private InputController _inputController;
        private TickableManager _tickableManager;
        
        private void Start()
        {
            CreateTickableManager();
            _inputController = new InputController(_tickableManager);
            _playerController = new PlayerController(_inputController);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _playerController.AnimationGetDamage();
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerController.AnimationDeath();
            }
        }
        
        private void CreateTickableManager()
        {
            var tickableManagerPrefab = Resources.Load<TickableManager>(
                ResourcesConst.ResourcesConst.TickableManager);
            _tickableManager = Instantiate(tickableManagerPrefab);
        }
    }
}