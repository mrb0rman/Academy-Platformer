using DG.Tweening;
using Scenes;
using UnityEngine;

namespace Academy.Platformer.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private readonly InputController _inputController;
        private readonly TemporaryPlayerView _temporaryPlayerView;
        private float _playerLength;
        private float _cameraHalfWidth;
        private float _offsetFromEdge;
        private const float Epsilon = 0.1f;

        public PlayerMovementController(
            InputController inputController,
            TemporaryPlayerView temporaryPlayerView)
        {
            _playerLength = transform.localScale.x;
            _cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            _offsetFromEdge = _playerLength / 2;
            
            _inputController = inputController;
            _temporaryPlayerView = temporaryPlayerView;
            
            _inputController.OnLeftEvent.AddListener(MoveLeft);
            _inputController.OnRightEvent.AddListener(MoveRight);
        }

        private void MoveLeft()
        {
            var playerLeftEdgeX = transform.position.x - _playerLength / 2;
            if (playerLeftEdgeX + _cameraHalfWidth > Epsilon)
                transform.DOMove(Vector3.left, 1f);
            else
                transform.position = new Vector3(-_cameraHalfWidth + _offsetFromEdge, transform.position.y, 0f);
        }
        private void MoveRight()
        {
            var playerRightEdgeX = transform.position.x + _playerLength / 2;
            if (_cameraHalfWidth - playerRightEdgeX > Epsilon)
                transform.DOMove(Vector3.right, 1f);
            else
                transform.position = new Vector3(_cameraHalfWidth - _offsetFromEdge, transform.position.y, 0f);
        }
    }
}

