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

        private const float Speed = 5f;
        private const float Offset = 3f;
        private const float Epsilon = 0.1f;
        
        private float _playerLength;
        private float _cameraHalfWidth;
        private float _offsetFromEdge;

        private bool _touchesLeftWall;
        private bool _touchesRightWall;

        public PlayerMovementController(
            InputController inputController,
            PlayerView playerView)
        {
            _playerLength = playerView.gameObject.transform.localScale.x;
            _offsetFromEdge = _playerLength / 2;
            _playerView = playerView;
            _inputController = inputController;
            _cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            _touchesLeftWall = false;
            _touchesRightWall = false;

            _inputController.OnLeftEvent.AddListener(MoveLeft);
            _inputController.OnRightEvent.AddListener(MoveRight);
        }
        
        private void MoveLeft()
        {
            var playerTransform = _playerView.gameObject.transform;
            var playerLeftEdgeX = playerTransform.position.x - _offsetFromEdge;

            _touchesLeftWall = playerTransform.position.x == -_cameraHalfWidth + _offsetFromEdge;
            
            if (playerLeftEdgeX + Vector3.left.x * Offset + _cameraHalfWidth > Epsilon && !_touchesLeftWall)
                playerTransform.DOMove(playerTransform.position + Vector3.left * Offset, Speed).
                    SetSpeedBased().SetEase(Ease.Linear);
            else
            {
                playerTransform.DOMove(new Vector3(-_cameraHalfWidth + _offsetFromEdge, 
                    playerTransform.position.y, 0f), Speed).
                    SetSpeedBased().SetEase(Ease.Linear);
            }
        }
        private void MoveRight()
        {
            var playerTransform = _playerView.gameObject.transform;
            var playerRightEdgeX = playerTransform.position.x + _offsetFromEdge;
            
            _touchesRightWall = playerTransform.position.x == _cameraHalfWidth - _offsetFromEdge;

            if (_cameraHalfWidth + Vector3.left.x * Offset - playerRightEdgeX > Epsilon && !_touchesRightWall)
                playerTransform.DOMove(playerTransform.position + Vector3.right * Offset, Speed).
                    SetSpeedBased().SetEase(Ease.Linear);
            else
            {
                playerTransform.DOMove(new Vector3(_cameraHalfWidth - _offsetFromEdge,
                    playerTransform.position.y, 0f), Speed).
                    SetSpeedBased().SetEase(Ease.Linear);
            }
        }
    }
}