using Academy.Platformer.Player;
using FactoryPlayer;
using Scenes;
using UnityEngine;

public class PlayerMovementCreator : MonoBehaviour
{
    private TickableManager tickableManager;
    private PlayerView playerView;
    
    private InputController _inputController;
    
    private void Start()
    {
        _inputController = new InputController(tickableManager);
        new PlayerMovementController(_inputController, playerView);
    }
}
