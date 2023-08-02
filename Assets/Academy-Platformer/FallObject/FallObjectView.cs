using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [HideInInspector] public int PointsPerObject;
        [HideInInspector] public int Damage;
    }
}