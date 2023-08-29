using System;
using Academy_Platformer.Player.FactoryPlayer;
using Sounds;
using UI.HUD;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Player
{
    public class PlayerController
    {
        public event Action<float> OnChangeSpeed;

        public PlayerHpController PlayerHpController => _playerHpController;

        private SoundController _soundController;
        private InputController _inputController;
        private PlayerConfig _playerConfig;
        private PlayerView _playerView;
        private PlayerHpController _playerHpController;
        private IFactoryCharacter _factoryPlayer;
        private PlayerStorage _playerStorage;
        private PlayerMovementController _playerMovementController;
        private PlayerAnimator _playerAnimator;
        private UnityEngine.Camera _camera;
        
        private float _currentHealth;
        private float _currentSpeed;

        public PlayerController(
            InputController inputController,
            HUDWindowController hudWindowController,
            UnityEngine.Camera camera,
            SoundController soundController)
        {
            _soundController = soundController;
            
            _playerConfig = Resources.Load<PlayerConfig>(ResourcesConst.PlayerConfig);

            _playerHpController = new PlayerHpController(_playerConfig.PlayerModel.Health, _soundController);
            _playerHpController.OnHealthChanged += hudWindowController.ChangeHealthPoint;
          
            _inputController = inputController;
            _camera = camera;
            
            
            _playerStorage = new PlayerStorage();
            _factoryPlayer = new FactoryPlayer();
        }
        
        public PlayerView Spawn()
        {
            var model = _playerConfig.PlayerModel;
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            _playerView = _factoryPlayer.Create(model, _playerView);
            
            _playerAnimator = new PlayerAnimator(_playerView, _camera);
            _playerAnimator.Spawn();
            
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
            _soundController.Stop();
            _soundController.Play(SoundName.GameOver);
            
            Object.Destroy(_playerView.gameObject);
            _playerView = null;
        }
    }
}