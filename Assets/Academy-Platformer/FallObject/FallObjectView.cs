using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
    }
}