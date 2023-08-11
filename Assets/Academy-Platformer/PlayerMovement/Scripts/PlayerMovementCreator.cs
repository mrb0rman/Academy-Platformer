using FactoryPlayer;
using Scenes;
using UnityEngine;

namespace Academy.Platformer.Player
{
    public class PlayerMovementCreator : MonoBehaviour
    {
        private TickableManager _tickableManager;
        private PlayerView _playerView;
    
        private InputController _inputController;
    
        private void Start()
        {
            _tickableManager = GameObjectStorage.GetInstance().TickableManager;
            _playerView = GameObjectStorage.GetInstance().PlayerView;
        
            _inputController = new InputController(_tickableManager);
            new PlayerMovementController(_inputController, _playerView);
        }
    }
}
