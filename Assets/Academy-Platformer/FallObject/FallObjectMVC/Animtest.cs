using System;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class Animtest : MonoBehaviour
    {
        [SerializeField] private FallObjectView view;

        private FallObjectAnimator _animator;

        private void Start()
        {
            _animator = new FallObjectAnimator(view);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.Death();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _animator.Spawn();
            }
        }
    }
}