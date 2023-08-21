using System;
using FactoryPlayer;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectController
    {
        public event Action<FallObjectController> PlayerCatchFallingObjectNotify; 
        public event Action<FallObjectController> ObjectFellNotify;

        public FallObjectView View => _view;
        private FallObjectAnimator _animator;
        public int PointsPerObject => _pointsPerObject;
        public int Damage => _damage;

        private FallObjectView _view;
        
        private int _pointsPerObject;
        private int _damage;
        private float _fallSpeed;

        private Vector3 _deltaVector = new Vector3(0, -0.001f, 0);

        public FallObjectController(
            FallObjectView view, 
            FallObjectModel model)
        {
            TickableManager.FixedUpdateNotify += FixedUpdate;

            _pointsPerObject = model.PointsPerObject;
            _damage = model.Damage;
            _fallSpeed = model.FallSpeed;

            _view = view;
            _view.OnCollisionEnter2DNotify += OnCollisionEnter2D;
        }

        void OnCollisionEnter2D(Collision2D collision2D)
        {
            var player = collision2D.gameObject.GetComponent<PlayerView>();
            if (player != null)
            {
                PlayerCatchFallingObjectNotify?.Invoke(this);
            }          
        }

        public void ChangeFallSpeed(float speed)
        {
            _fallSpeed = speed;
        }
        
        private void FixedUpdate()
        {
            _view.transform.position += _deltaVector * _fallSpeed;
        }
    }
}