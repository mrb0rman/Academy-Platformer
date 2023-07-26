using System;
using Bootstrap.Interface;

namespace Bootstrap
{
    public abstract class Command : ICommand
    {
        public event Action CommandExecuteNotify;

        public virtual void Execute()
        {
            CommandExecuteNotify?.Invoke();
        }

        public virtual void Undo()
        {
        }
    }
}