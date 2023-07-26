using System.Collections.Generic;
using Bootstrap.Interface;
using UnityEngine;

namespace Bootstrap
{
    public class Bootstrap : IBootstrap
    {
        private Queue<ICommand> _queueCommands = new Queue<ICommand>();

        public bool Add(ICommand command)
        {
            if (command == null)
            {
                return false;
            }

            _queueCommands.Enqueue(command);
            return true;
        }

        public bool Start()
        {
            if (_queueCommands.Count == 0)
            {
                return false;
            }

            Execute();
            return true;
        }

        public void Execute()
        {
            if (_queueCommands.Count == 0)
            {
                Debug.Log("All commands executed");
                return;
            }

            var command = _queueCommands.Dequeue();
            command.CommandExecuteNotify += Execute;
            command.Execute();
        }
    }
}