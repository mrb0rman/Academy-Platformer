using System;
using Academy_Platformer.Command;

namespace Academy_Platformer.Bootstrap.Interface
{
    public interface IBootstrap
    {
        event Action OnExecuteAllComandsNotify;
        void Add(ICommand command);
        void Execute();
    }
}