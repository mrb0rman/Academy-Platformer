using System;
using Player;
using UnityEngine;

namespace FallObject
{
    public class FallObjectController
    {
        public event Action<FallObjectController> PlayerCatchFallingObjectNotify; 
        public event Action<FallObjectController> ObjectFellNotify;
        public int PointsPerObject => _pointsPerObject;
        public FallObjectView View => _view;
        public int Damage => _damage;
        
        private Vector3 _deltaVector = new Vector3(0, -0.001f, 0);
        private FallObjectAnimator _animator;
        private FallObjectView _view;
        private int _pointsPerObject;
        private float _minPositionY = -7f;
        private float _fallSpeed;
        private int _damage;


        public FallObjectController(
            FallObjectView view, 
            FallObjectModel model)
        {
            _pointsPerObject = model.PointsPerObject;
            _fallSpeed = model.FallSpeed;
            _damage = model.Damage;
            _view = view;
            
            _animator = new FallObjectAnimator(view);
            _animator.Spawn();
            
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

        private void FixedUpdate()
        {
            if (_view.transform.position.y <= _minPositionY)
            {
                ObjectFellNotify?.Invoke(this);
            }
            _view.transform.position += _deltaVector * _fallSpeed;
        }

        public void SetActive(bool value)
        {
            if (value == true)
            {
                TickableManager.TickableManager.FixedUpdateNotify += FixedUpdate;
            }
            else
            {
                TickableManager.TickableManager.FixedUpdateNotify -= FixedUpdate;
            }
            View.gameObject.SetActive(value);
        }
    }
}