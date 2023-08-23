using Academy_Platformer.UI.HUD;
using UIService;

namespace Academy_Platformer.UI
{
    public class CreateUICommand : Academy_Platformer.Command.Command
    {
        public CreateUICommand(ref HUDWindowController hudWindowController, UnityEngine.Camera camera)
        {
            var UIService = new Academy_Platformer.UI.UIService.UIService(camera);
            
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