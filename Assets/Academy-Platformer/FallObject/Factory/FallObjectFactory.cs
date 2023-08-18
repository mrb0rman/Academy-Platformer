using UnityEngine;

namespace Academy_Platformer.FallObject.Factory
{
    public class FallObjectFactory
    {
        private FallObjectConfig _objectConfig = Resources.Load<FallObjectConfig>(ResourcesConst.ResourcesConst.FallObjectConfigPath);
        private FallObjectView _objectView = Resources.Load<FallObjectView>(ResourcesConst.ResourcesConst.FallObjectViewPath);

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