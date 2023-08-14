using System;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectView : MonoBehaviour
    {
        public Action<FallObjectView> OnDeathEvent;
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public event Action<FallObjectView, Collision2D> OnCollisionEnter2DNotify; 
        
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter2DNotify?.Invoke(this, other);
        }
    }
}