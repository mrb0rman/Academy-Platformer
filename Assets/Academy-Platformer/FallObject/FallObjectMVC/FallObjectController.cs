using System;
using System.Collections.Generic;
using Academy_Platformer.FallObject.Factory;
using FactoryPlayer;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectController
    {
        public event Action<FallObjectModel> PlayerCatchFallingObjectNotify; 
        public event Action<FallObjectModel> ObjectFellNotify; 
        
        private readonly FallObjectFactory _factory = new();

        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ResourcesConst.ResourcesConst.FallObjectConfigPath);
        private List<FallObject> _fallObjects = new List<FallObject>();
        
        private const float FallSpeed = 1.0f;

        private Vector3 _deltaVector = new Vector3(0, -0.00001f, 0);

        public FallObjectController()
        {
        }

        public FallObjectView CreateObject(FallObjectType type)
        {
            var view = _factory.Create(type);
            var model = _objectConfig.Get(type);
            
            view.OnCollisionEnter2DNotify += OnCollisionEnter2D;
            
            _fallObjects.Add(new FallObject(view, model));
            
            return view;
        }

        public void StartUpdate()
        {
            TickableManager.FixedUpdateNotify += FixedUpdate;
        }
        public void StopUpdate()
        {
            TickableManager.FixedUpdateNotify += FixedUpdate;
        }

        void OnCollisionEnter2D(FallObjectView view, Collision2D collision2D)
        {
            var player = collision2D.gameObject.GetComponent<PlayerView>();
            if (player != null)
            {
                var model = _fallObjects.Find(fallObject => fallObject.View == view).Model;
                PlayerCatchFallingObjectNotify?.Invoke(model);
            }          
        }
        private void FixedUpdate()
        {
            if (_fallObjects.Count == 0)
            {
                return;
            }
            foreach (var fallObject in _fallObjects)
            {
                fallObject.View.transform.position += _deltaVector * FallSpeed;
            }
        }
    }
}