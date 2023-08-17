using UIService;

namespace CreatingCommand
{
    public class CreateUICommand : Command.Command
    {
        public CreateUICommand()
        {
            var UIService = new UIService.UIService();
            
            var mainMenuWindowContrroler = new UIMainMenuController(UIService);
            var gameWindowController = new UIGameWindowController(UIService);
            var endMenuWindowController = new UIEndGameWindowController(UIService);
            var hudWindowController = new HUDWindowController(UIService);
            
            UIService.Show<UIMainMenuWindow>();
            
            var mainWindow = UIService.Get<UIMainMenuWindow>();
            mainWindow.OnStartButtonClickEvent += ()=>
            {
                new GameController();
            };
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