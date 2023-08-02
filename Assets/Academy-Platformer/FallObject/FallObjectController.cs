using Academy_Platformer.FallObject.Factory;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectController
    {
        private int _pointsPerObject;
        private int _damage;
        private readonly FallObjectFactory _factory = new();

        public GameObject CreateObject(FallObjectType type)
        {
            var view = _factory.Create(type);
            _pointsPerObject = view.PointsPerObject;
            _damage = view.Damage;

            return view.gameObject;
        }
    }
}