using Academy_Platformer.HPController;
using DG.Tweening;
using UnityEngine;

namespace FactoryPlayer
{
    public class PlayerAnimator
    {
        private PlayerView _playerView;
        
        private Sequence _sequenceSpawn;
        private Sequence _sequenceGetDamage;
        private Sequence _sequenceDeath;

        private float _durationGetDamage = 0.1f;
        private float _durationDeath = 1f;
        
        public PlayerAnimator(PlayerView playerView)
        {
            _playerView = playerView;
        }
        
        public void Spawn()
        {
            _playerView.transform.position = new Vector3(-14, -3, 0);
            
            _sequenceSpawn?.Kill();
            
            _sequenceSpawn = DOTween.Sequence();
            
            _sequenceSpawn.Append(_playerView.transform.
                DOMove(new Vector3(0, -3, 0), 5f).
                SetEase(Ease.OutBack).SetDelay(1f));
        }
        
        public void GetDamage()
        {
            _sequenceGetDamage?.Kill();
            
            _sequenceGetDamage = DOTween.Sequence();
            
            _sequenceGetDamage.Append(_playerView.SpriteRenderer.DOColor(new Color(
                _playerView.SpriteRenderer.color.r,
                _playerView.SpriteRenderer.color.g,
                _playerView.SpriteRenderer.color.b,
                0), _durationGetDamage)).Append(_playerView.SpriteRenderer.DOColor(new Color(
                _playerView.SpriteRenderer.color.r,
                _playerView.SpriteRenderer.color.g,
                _playerView.SpriteRenderer.color.b,
                1), _durationGetDamage)).SetLoops(5);
        }

        public void Death()
        {
            _sequenceDeath?.Kill();
                
            _sequenceDeath = DOTween.Sequence();
            
            _sequenceDeath.Append(_playerView.transform.DOScale(0.7f, _durationDeath).
                SetEase(Ease.InOutBounce)
                .OnComplete(() => _playerView.transform.DOScale(0f, _durationDeath).
                    SetEase(Ease.InBounce)));
        }
    }
}