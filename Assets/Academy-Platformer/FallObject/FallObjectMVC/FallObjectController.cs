using Academy_Platformer.FallObject.Factory;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectController
    {
        private readonly FallObjectFactory _factory = new();
        
        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ResourcesConst.ResourcesConst.FallObjectConfigPath);

        private int _pointsPerObject;
        
        private int _damage;

        public GameObject CreateObject(FallObjectType type)
        {
            var view = _factory.Create(type);
            var model = _objectConfig.Get(type);

            _pointsPerObject = model.PointsPerObject;
            _damage = model.Damage;

            return view.gameObject;
        }
    }
}