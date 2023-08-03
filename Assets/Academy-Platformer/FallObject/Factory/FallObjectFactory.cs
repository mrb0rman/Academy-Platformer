using UnityEngine;

namespace Academy_Platformer.FallObject.Factory
{
    public class FallObjectFactory
    {
        private const string ConfigPath = "FallObjectConfig";
        private const string ViewPath = "FallObject";
        
        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ConfigPath);
        private FallObjectView _objectView = Resources.Load<FallObjectView>(ViewPath);

        public FallObjectView Create(FallObjectType type)
        {
            var view = GameObject.Instantiate(_objectView);
            var model = _objectConfig.Get(type);

            return view;
        }
    }
}