using Academy.Platformer.Player;
using FactoryPlayer;
using Scenes;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private EventManager eventManager;
    [SerializeField] private PlayerView playerView;
    
    private InputController _inputController;
    private PlayerMovementController _playerMovementController;
    
    private void Start()
    {
        _inputController = new InputController(eventManager);
        _playerMovementController = new PlayerMovementController(_inputController, playerView);
    }
}
