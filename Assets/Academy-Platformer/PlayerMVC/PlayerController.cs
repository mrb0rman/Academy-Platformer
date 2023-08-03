using System;
using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class PlayerController
    {
        public event Action<float> OnChangeSpeed;
        
        private PlayerConfig _playerConfig;
        private IFactoryCharacter _factoryPlayer;
        private PlayerView _playerView;
        
        private float _currentHealth;
        private float _currentSpeed;
       
        public PlayerController()
        {
            _playerConfig = Resources.Load<PlayerConfig>("PlayerConfig");

            _factoryPlayer = new FactoryPlayer(_playerConfig);
        }
        
        public void Spawn()
        {
            var model = _playerConfig.Get();
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            _playerView = _factoryPlayer.Create();
        }
        
        public void ChangeHealth(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth > 0)
            {
                _playerView.ChangeHealth(_currentHealth);
            }
            else
            {
                _playerView.Death();
            }
        }

        public void SetSpeed(float newSpeed)
        {
            _currentSpeed = newSpeed;
            
            OnChangeSpeed?.Invoke(_currentSpeed);
        }
    }
}