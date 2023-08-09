using System;
namespace Command
{
    public abstract class Command : ICommand
    {
        public virtual event Action OnCommandExecuteNotify;

        public virtual void Execute()
        {
            OnCommandExecuteNotify?.Invoke();
        }
        public abstract void Undo();
    }
}