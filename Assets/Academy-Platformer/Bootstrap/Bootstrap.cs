using System;
using System.Collections.Generic;
using Command;
using UnityEngine;
namespace Bootstrap
{
    public class Bootstrap : IBootstrap
    {
        private Queue<ICommand> _queueCommands = new Queue<ICommand>();
        private event Action OnExecuteAllComandsNotify;
        private bool _isInit;
        private void Init()
        {
            OnExecuteAllComandsNotify += CompletingBootstrap;
            _isInit = !_isInit;
        }
        public void Add(ICommand command)
        {
            if (!_isInit)
            {
                Init();
            }
            if (command == null)
            {
                Debug.LogError("The command is null");
                return;
            }
            _queueCommands.Enqueue(command);
        }
        public void Execute()
        {
            if (_queueCommands.Count == 0)
            {
                OnExecuteAllComandsNotify?.Invoke();
                return;
            }
            var command = _queueCommands.Dequeue();
            command.OnCommandExecuteNotify += Execute;
            command.Execute();
        }
        private void CompletingBootstrap()
        {
            Debug.Log("All commands executed");
        }
    }
}