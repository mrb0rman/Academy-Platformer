using DG.Tweening;
using Scenes;
using UnityEngine;

namespace Academy.Platformer.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        
        private readonly InputController _inputController;
        private readonly TemporaryPlayerView _temporaryPlayerView;
        
        private const float Epsilon = 0.1f;
        
        private float _playerLength;
        private float _cameraHalfWidth;
        private float _offsetFromEdge;

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
            var playerLeftEdgeX = transform.position.x - _offsetFromEdge;
            if (playerLeftEdgeX + Vector3.left.x * speed + _cameraHalfWidth > Epsilon)
                transform.DOMove(transform.position + Vector3.left * speed, 1f);
            else
                transform.DOMove(new Vector3(-_cameraHalfWidth + _offsetFromEdge, 
                    transform.position.y, 0f), 1f);
        }
        private void MoveRight()
        {
            var playerRightEdgeX = transform.position.x + _offsetFromEdge;
            if (_cameraHalfWidth + Vector3.left.x * speed - playerRightEdgeX > Epsilon)
                transform.DOMove(transform.position + Vector3.right * speed, 1f);
            else
                transform.DOMove(new Vector3(_cameraHalfWidth - _offsetFromEdge, 
                    transform.position.y, 0f), 1f);
        }
    }
}

