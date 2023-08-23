using System;

namespace Academy_Platformer.Command
{
    public interface ICommand
    {
        event Action OnCommandExecuteNotify;
        void Execute();
        void Undo();
    }
}