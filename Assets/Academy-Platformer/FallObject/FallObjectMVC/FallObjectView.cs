using UnityEngine;
using UnityEngine.Serialization;

namespace Academy_Platformer.FallObject
{
    public class FallObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
    }
}