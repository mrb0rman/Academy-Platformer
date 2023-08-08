using DG.Tweening;
using FactoryPlayer;
using Scenes;
using UnityEngine;

namespace Academy.Platformer.Player
{
    public class PlayerMovementController
    {
        private readonly InputController _inputController;
        private readonly PlayerView _playerView;

        private const float Speed = 100f;
        private const float Offset = 3f;
        private const float Epsilon = 0.01f;

        private float _playerLength;
        private float _cameraHalfWidth;
        private float _offsetFromEdge;
        private float _step;

        public PlayerMovementController(
            InputController inputController,
            PlayerView playerView)
        {
            _playerLength = playerView.gameObject.transform.localScale.x;
            _offsetFromEdge = 2 * _playerLength;
            _playerView = playerView;
            _inputController = inputController;
            _cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            _step = Speed * Time.deltaTime;

            _inputController.OnLeftEvent.AddListener(MoveLeft);
            _inputController.OnRightEvent.AddListener(MoveRight);
        }
        
        private void MoveLeft()
        {
            var playerTransform = _playerView.gameObject.transform;
            var playerPosition = playerTransform.position;
            var playerLeftEdgeX = playerTransform.position.x - _offsetFromEdge;

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
            var playerRightEdgeX = playerTransform.position.x + _offsetFromEdge;

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
}