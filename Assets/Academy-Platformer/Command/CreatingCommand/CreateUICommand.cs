using UIService;

namespace CreatingCommand
{
    public class CreateUICommand : Command.Command
    {
        public CreateUICommand(UIService.UIService uiService ,ref HUDWindowController hudWindowController)
        {
            var mainMenuWindowContrroler = new UIMainMenuController(uiService);
            var gameWindowController = new UIGameWindowController(uiService);
            var endMenuWindowController = new UIEndGameWindowController(uiService);
            hudWindowController = new HUDWindowController(uiService);
            
            uiService.Show<UIMainMenuWindow>();
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}