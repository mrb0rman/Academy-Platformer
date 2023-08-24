using System;
using Academy_Platformer.Player.FactoryPlayer;
using Academy_Platformer.UI.HUD;
using UnityEngine;

namespace Academy_Platformer.Player
{
    public class PlayerController
    {
        public event Action<float> OnChangeSpeed;

        public PlayerHpController PlayerHpController => _playerHpController;
        
        private InputController _inputController;
        private PlayerConfig _playerConfig;
        private PlayerView _playerView;
        private PlayerHpController _playerHpController;
        private IFactoryCharacter _factoryPlayer;
        private PlayerStorage _playerStorage;
        private PlayerMovementController _playerMovementController;
        private PlayerAnimator _playerAnimator;
        
        private float _currentHealth;
        private float _currentSpeed;

        public PlayerController(
            InputController inputController,
            HUDWindowController hudWindowController)
        {
            _playerConfig = Resources.Load<PlayerConfig>(ResourcesConst.PlayerConfig);

            _playerHpController = new PlayerHpController(_playerConfig.PlayerModel.Health);
            _playerHpController.OnHealthChanged += hudWindowController.ChangeHealthPoint;
          
            _inputController = inputController;
            
            _playerStorage = new PlayerStorage();
            _factoryPlayer = new FactoryPlayer.FactoryPlayer();
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