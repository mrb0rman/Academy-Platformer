using Academy_Platformer.FallObject.Factory;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectController
    {
        public float FallSpeed = 1.0f;
        
        private  FallObjectView _view;

        private readonly FallObjectFactory _factory = new();
        
        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ResourcesConst.ResourcesConst.FallObjectConfigPath);

        private int _pointsPerObject;
        
        private int _damage;

        public GameObject CreateObject(FallObjectType type)
        {
            _view = _factory.Create(type);
            var model = _objectConfig.Get(type);

            _pointsPerObject = model.PointsPerObject;
            _damage = model.Damage;
            TickableManager.FixedUpdateEventHandler += FixedUpdate;
            
            return _view.gameObject;
        }
        private void FixedUpdate()
        {
            _view.transform.position += new Vector3(0, -0.001f, 0) * FallSpeed;
        }
    }
}