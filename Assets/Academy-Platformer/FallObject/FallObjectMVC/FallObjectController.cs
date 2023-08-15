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
        public float FallSpeed => _fallSpeed;
        
        private readonly FallObjectFactory _factory = new();

        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ResourcesConst.ResourcesConst.FallObjectConfigPath);
        private List<FallObject> _fallObjects;
        
        private float _fallSpeed = 1.0f;

        public FallObjectController()
        {
            TickableManager.FixedUpdateNotify += FixedUpdate;
        }

        public FallObjectView CreateObject(FallObjectType type)
        {
            var view = _factory.Create(type);
            var model = _objectConfig.Get(type);
            
            view.OnCollisionEnter2DNotify += OnCollisionEnter2D;
            
            _fallObjects.Add(new FallObject(view, model));
            
            return view;
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
            foreach (var fallObject in _fallObjects)
            {
                fallObject.View.transform.position += new Vector3(0, -0.001f, 0) * FallSpeed;
            }
        }
    }
}