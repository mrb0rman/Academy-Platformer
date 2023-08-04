using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Academy_Platformer.FallObject
{
    public class FallObjectView : MonoBehaviour
    {
        public float FallSpeed = 1.0f;
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Update()
        {
            transform.position += new Vector3(0, -0.001f, 0) * FallSpeed;
        }
    }
}