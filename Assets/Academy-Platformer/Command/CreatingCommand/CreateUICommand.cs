using UIService;
using UnityEngine;

namespace CreatingCommand
{
    public class CreateUICommand : Command.Command
    {
        public CreateUICommand(ref HUDWindowController hudWindowController, Camera camera)
        {
            var UIService = new UIService.UIService(camera);
            
            var mainMenuWindowContrroler = new UIMainMenuController(UIService);
            var gameWindowController = new UIGameWindowController(UIService);
            var endMenuWindowController = new UIEndGameWindowController(UIService);
            hudWindowController = new HUDWindowController(UIService);
            
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