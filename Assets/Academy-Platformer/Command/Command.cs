using System;
namespace Command
{
    public abstract class Command : ICommand
    {
        public abstract event Action OnCommandExecuteNotify;
        public abstract void Execute();
        public abstract void Undo();
    }
}