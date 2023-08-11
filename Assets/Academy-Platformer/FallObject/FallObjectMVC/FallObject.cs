namespace Academy_Platformer.FallObject
{
    public class FallObject
    {
        private FallObjectView _view;
        private FallObjectModel _model;
        public FallObjectView View => _view;
        public FallObjectModel Model => _model;

        public FallObject(FallObjectView view, FallObjectModel model)
        {
            _view = view;
            _model = model;
        }
    }
}