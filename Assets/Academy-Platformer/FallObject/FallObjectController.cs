using Academy_Platformer.FallObject.Factory;
using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectController
    {
        private readonly FallObjectFactory _factory = new();

        public GameObject CreateObject(FallObjectType type)
        {
            var view = _factory.Create(type);

            return view.gameObject;
        }
    }
}