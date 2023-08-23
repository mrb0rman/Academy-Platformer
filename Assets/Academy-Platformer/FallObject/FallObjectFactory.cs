using UnityEngine;

namespace Academy_Platformer.FallObject
{
    public class FallObjectFactory
    {
        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ResourcesConst.FallObjectConfigPath);
        private FallObjectView _objectView = Resources.Load<FallObjectView>(ResourcesConst.FallObjectViewPath);

        public FallObjectController Create(FallObjectType type)
        {
            var view = GameObject.Instantiate(_objectView);
            var model = _objectConfig.Get(type);
            var controller = new FallObjectController(view, model);

            view.SpriteRenderer.sprite = model.ObjectSprite;

            return controller;
        }
    }
}