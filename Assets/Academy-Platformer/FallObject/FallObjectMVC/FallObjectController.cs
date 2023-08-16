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
        public int PointsPerObject => _pointsPerObject;
        public int Damage => _damage;

        private const float FallSpeed = 1.0f;

        private FallObjectView _view;
        
        private int _pointsPerObject;
        private int _damage;

        private Vector3 _deltaVector = new Vector3(0, -0.001f, 0);

        public FallObjectController(
            FallObjectView view, 
            FallObjectModel model)
        {
            TickableManager.FixedUpdateNotify += FixedUpdate;

            _pointsPerObject = model.PointsPerObject;
            _damage = model.Damage;

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
        private void FixedUpdate()
        {
            _view.transform.position += _deltaVector * FallSpeed;
        }
    }
}