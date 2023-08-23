using DG.Tweening;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectAnimator
    {
        private const float SpawnAnimDuration = 0.5f;
        private const float DeathAnimDuration = 0.5f;
    
        private FallObjectView _fallObjectView;
    
        private Sequence _sequenceSpawn;
        private Sequence _sequenceDeath;

        public FallObjectAnimator(FallObjectView fallObjectView)
        {
            _fallObjectView = fallObjectView;
        }

        public void Spawn()
        {
            _sequenceSpawn?.Kill();

            _sequenceSpawn = DOTween.Sequence();

            _fallObjectView.transform.localScale = Vector3.zero;
            _sequenceSpawn.Append(_fallObjectView.transform.DOScale(Vector3.one, SpawnAnimDuration));
        }

        public void Death()
        {
            _sequenceDeath?.Kill();

            _sequenceDeath = DOTween.Sequence();

            _sequenceDeath.Append(_fallObjectView.transform.DOScale(Vector3.zero, DeathAnimDuration));
        }
    }
}