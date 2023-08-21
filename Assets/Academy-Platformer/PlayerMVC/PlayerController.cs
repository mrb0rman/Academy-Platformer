using System;
using Academy_Platformer.HPController;
using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class PlayerController
    {
        public event Action<float> OnChangeSpeed;

        public HPController HpController => _hpController;
        
        private InputController _inputController;
        private PlayerConfig _playerConfig;
        private PlayerView _playerView;
        private HPController _hpController;
        private IFactoryCharacter _factoryPlayer;
        private PlayerStorage _playerStorage;
        private PlayerMovementController _playerMovementController;
        private PlayerAnimator _playerAnimator;
        
        private float _currentHealth;
        private float _currentSpeed;

        public PlayerController(InputController inputController)
        {
            _playerConfig = Resources.Load<PlayerConfig>(ResourcesConst.ResourcesConst.PlayerConfig);

            _hpController = new HPController(_playerConfig.PlayerModel.Health);
          
            _inputController = inputController;
            
            _playerStorage = new PlayerStorage();
            _factoryPlayer = new FactoryPlayer();
        }
        
        public PlayerView Spawn()
        {
            var model = _playerConfig.PlayerModel;
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            _playerView = _factoryPlayer.Create(model, _playerView);
            
            _playerStorage.Add(_playerView);
            _playerMovementController = new PlayerMovementController(_inputController, _playerView);
            
            return _playerView;
        }

        public void SetSpeed(float newSpeed)
        {
            _currentSpeed = newSpeed;

            OnChangeSpeed?.Invoke(_currentSpeed);
        }

        public void DestroyView()
        {
            GameObject.Destroy(_playerView.gameObject);
            _playerView = null;
        }
    }
}