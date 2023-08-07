using Academy.Platformer.Player;
using FactoryPlayer;
using Scenes;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private PlayerView playerView;

    private PlayerMovementController _playerMovementController;

    private void Start()
    {
        _playerMovementController = new PlayerMovementController(inputController, playerView);
    }
}
