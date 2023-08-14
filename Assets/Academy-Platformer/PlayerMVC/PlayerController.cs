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
        
        private PlayerConfig _playerConfig;
        private IFactoryCharacter _factoryPlayer;
        private PlayerView _playerView;
        private HPController _hpController;
        
        private float _currentHealth;
        private float _currentSpeed;
       
        public PlayerController()
        {
            _playerConfig = Resources.Load<PlayerConfig>(ResourcesConst.ResourcesConst.PlayerConfig);

            _hpController = new HPController(_playerConfig.PlayerModel.Health);
            
            _factoryPlayer = new FactoryPlayer();
        }
        
        public PlayerView Spawn()
        {
            var model = _playerConfig.PlayerModel;
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            _playerView = _factoryPlayer.Create(model, _playerView);
            
            return _playerView;
        }
        

        public void SetSpeed(float newSpeed)
        {
            _currentSpeed = newSpeed;
            
            OnChangeSpeed?.Invoke(_currentSpeed);
        }
    }
}