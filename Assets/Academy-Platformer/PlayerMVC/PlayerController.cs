using System;
using Academy_Platformer.HPController;
using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class PlayerController
    {
        public event Action<float> OnChangeSpeed;
        public event Action OnSpawn;
        public event Action OnGetDamage;

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
            
            _playerAnimator = new PlayerAnimator(
                this, 
                _playerView, 
                _hpController);
        }

        public PlayerView Spawn()
        {
            var model = _playerConfig.PlayerModel;
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            _playerView = _factoryPlayer.Create(model, _playerView);
            
            AnimationSpawn();

            return _playerView;
        }

        public void SetSpeed(float newSpeed)
        {
            _currentSpeed = newSpeed;
            
            OnChangeSpeed?.Invoke(_currentSpeed);
        }
        
        public void AnimationSpawn()
        {
            OnSpawn?.Invoke();
        }
        
        public void AnimationGetDamage()
        {
            OnGetDamage?.Invoke();
        }

        public void AnimationDeath()
        {
            _hpController.OnZeroHealth?.Invoke();
        }
    }
}