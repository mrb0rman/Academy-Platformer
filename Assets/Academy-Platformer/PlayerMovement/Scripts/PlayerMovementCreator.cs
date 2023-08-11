using Academy.Platformer.Player;
using FactoryPlayer;
using Scenes;
using UnityEngine;

public class PlayerMovementCreator : MonoBehaviour
{
    private TickableManager _tickableManager;
    private PlayerView _playerView;
    
    private InputController _inputController;
    
    private void Start()
    {
        _tickableManager = GameObjectsStorage.GetInstance().TickableManager;
        _playerView = FindFirstObjectByType<PlayerView>();
        
        _inputController = new InputController(_tickableManager);
        new PlayerMovementController(_inputController, _playerView);
    }
}
