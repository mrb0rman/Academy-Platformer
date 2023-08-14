using System;
using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class PlayerController
    {
        public event Action<float> OnChangeSpeed;
        public event Action<float> OnChangeHealth;
        public event Action OnDeath;
        
        private InputController _inputController;
        private PlayerConfig _playerConfig;
        private PlayerView _playerView;
        private IFactoryCharacter _factoryPlayer;
        private PlayerStorage _playerStorage;
        private PlayerMovementController _playerMovementController;
        
        private float _currentHealth;
        private float _currentSpeed;

        public PlayerController(InputController inputController)
        {
            _inputController = inputController;
            
            _playerConfig = Resources.Load<PlayerConfig>(ResourcesConst.ResourcesConst.PlayerConfig);
            _playerStorage = new PlayerStorage();
            _factoryPlayer = new FactoryPlayer();

            PlayerSpawn();
        }

        private void PlayerSpawn()
        {
            _playerView = Spawn();
            _playerStorage.Add(_playerView);
            _playerMovementController = new PlayerMovementController(_inputController, _playerView);
        }

        public PlayerView Spawn()
        {
            var model = _playerConfig.PlayerModel;
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            _playerView = _factoryPlayer.Create(model, _playerView);
            
            return _playerView;
        }
        
        public void ChangeHealth(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth > 0)
            {
                OnChangeHealth?.Invoke(_currentHealth);
            }
            else
            {
                OnDeath?.Invoke();
            }
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