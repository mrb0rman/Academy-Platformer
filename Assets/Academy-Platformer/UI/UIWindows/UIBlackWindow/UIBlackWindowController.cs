namespace UIService
{
    public class UIBlackWindowController
    {
        private readonly UIService _uiService;
        private UIBlackWindow _blackWindow;

        public UIBlackWindowController(UIService uiService)
        {
            _uiService = uiService;
            _blackWindow = uiService.Get<UIBlackWindow>();
        }
    }
}