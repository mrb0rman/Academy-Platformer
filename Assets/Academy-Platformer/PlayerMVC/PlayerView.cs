using UnityEngine;

namespace FactoryPlayer
{
    public class PlayerView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void ChangeHealth(float newHealth)
        { }
        
        public void Death()
        { }
    }
}