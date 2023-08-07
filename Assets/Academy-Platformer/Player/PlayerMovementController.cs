using DG.Tweening;
using FactoryPlayer;
using Scenes;
using UnityEngine;

namespace Academy.Platformer.Player
{
    public class PlayerMovementController
    {
        [SerializeField] private float speed = 1f;
        
        private readonly InputController _inputController;
        private readonly PlayerView _playerView;
        
        private const float Epsilon = 0.1f;
        
        private float _playerLength;
        private float _cameraHalfWidth;
        private float _offsetFromEdge;

        public PlayerMovementController(
            InputController inputController,
            PlayerView playerView)
        {
            _playerLength = playerView.gameObject.transform.localScale.x;
            _cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            _offsetFromEdge = _playerLength / 2;
            
            _inputController = inputController;
            _playerView = playerView;
            
            _inputController.OnLeftEvent.AddListener(MoveLeft);
            _inputController.OnRightEvent.AddListener(MoveRight);
        }
        
        private void MoveLeft()
        {
            var playerTransform = _playerView.gameObject.transform;
            var playerLeftEdgeX = playerTransform.position.x - _offsetFromEdge;
            
            if (playerLeftEdgeX + Vector3.left.x * speed + _cameraHalfWidth > Epsilon)
                playerTransform.DOMove(playerTransform.position + Vector3.left * speed, 1f);
            else
                playerTransform.DOMove(new Vector3(-_cameraHalfWidth + _offsetFromEdge, 
                    playerTransform.position.y, 0f), 1f);
        }
        private void MoveRight()
        {
            var playerTransform = _playerView.gameObject.transform;
            var playerRightEdgeX = playerTransform.position.x + _offsetFromEdge;
            
            if (_cameraHalfWidth + Vector3.left.x * speed - playerRightEdgeX > Epsilon)
                playerTransform.DOMove(playerTransform.position + Vector3.right * speed, 1f);
            else
                playerTransform.DOMove(new Vector3(_cameraHalfWidth - _offsetFromEdge, 
                    playerTransform.position.y, 0f), 1f);
        }
    }
}

