using System;
using UnityEngine;

namespace UIService
{
    public class UIGameWindow : UIAnimationWindow
    {
        public Action OpenGameWindowEvent;
        public Transform[] SpawnPoints;
        public override void Show()
        {
            OpenGameWindowEvent?.Invoke();
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}