using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CreatingCommand
{
    public class CreateUICommand : Command.Command
    {
        private readonly GameObject _uiPrefab;
        private GameObject _ui;

        public CreateUICommand(GameObject ui)
        {
            _uiPrefab = ui;
        }

        public override void Execute()
        {
            _ui = Object.Instantiate(_uiPrefab);
            base.Execute();
        }

        public override void Undo()
        {
            Object.Destroy(_ui);
        }
    }
}