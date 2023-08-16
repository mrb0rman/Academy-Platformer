using UIService;

namespace CreatingCommand
{
    public class CreateUICommand : Command.Command
    {
        public CreateUICommand(UIService.UIService UIService)
        {
            
            var mainMenuWindowContrroler = new UIMainMenuController(UIService);
            var gameWindowController = new UIGameWindowController(UIService);
            var endMenuWindowController = new UIEndGameWindowController(UIService);
            
            UIService.Show<UIMainMenuWindow>();
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