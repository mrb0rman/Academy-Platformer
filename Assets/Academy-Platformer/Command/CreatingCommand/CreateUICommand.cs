using UIService;

namespace CreatingCommand
{
    public class CreateUICommand : Command.Command
    {
        public CreateUICommand(ref HUDWindowController hudWindowController)
        {
            
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