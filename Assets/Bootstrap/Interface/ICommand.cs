using System;

namespace Bootstrap.Interface
{
    public interface ICommand
    {
        public event Action CommandExecuteNotify; 
        public void Execute();
        public void Undo();
    }
}