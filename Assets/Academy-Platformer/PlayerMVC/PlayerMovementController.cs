using FactoryPlayer;
using UnityEngine;

public class PlayerMovementController
{
    private readonly PlayerView _playerView;

    private const float Speed = 5f;
    private const float Offset = 2f;
    private const float Epsilon = 0.01f;

    private readonly float _cameraHalfWidth;
    private readonly float _offsetFromEdge;
    private readonly float _step;

    public PlayerMovementController(InputController inputController, PlayerView playerView)
    {
        _playerView = playerView;

        var playerLength = playerView.gameObject.transform.localScale.x;
        _offsetFromEdge = 2 * playerLength;
        _step = Speed * Time.deltaTime;
        _cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        inputController.OnLeftEvent += MoveLeft;
        inputController.OnRightEvent += MoveRight;
    }

    private void MoveLeft()
    {
        var playerTransform = _playerView.gameObject.transform;
        var playerPosition = playerTransform.position;
        var playerLeftEdgeX = playerPosition.x - _offsetFromEdge;

        if (playerLeftEdgeX + Vector3.left.x * Offset + _cameraHalfWidth > Epsilon)
        {
            var target = playerPosition + Vector3.left * Offset;
            playerTransform.position = Vector3.MoveTowards(playerPosition, target, _step);
        }
        else
        {
            var target = new Vector3(-_cameraHalfWidth + _offsetFromEdge, playerPosition.y, 0f);
            playerTransform.position = Vector3.MoveTowards(playerPosition, target, _step);
        }
    }

    private void MoveRight()
    {
        var playerTransform = _playerView.gameObject.transform;
        var playerPosition = playerTransform.position;
        var playerRightEdgeX = playerPosition.x + _offsetFromEdge;

        if (_cameraHalfWidth + Vector3.left.x * Offset - playerRightEdgeX > Epsilon)
        {
            var target = playerTransform.position + Vector3.right * Offset;
            playerTransform.position = Vector3.MoveTowards(playerPosition, target, _step);
        }
        else
        {
            var target = new Vector3(_cameraHalfWidth - _offsetFromEdge, playerPosition.y, 0f);
            playerTransform.position = Vector3.MoveTowards(playerPosition, target, _step);
        }
    }
}