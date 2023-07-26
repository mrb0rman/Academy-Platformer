using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private UIRoot _uiRoot;
        private UIService _uiService;

        private void Start()
        {
            _uiService = new UIService(_uiRoot);
            _uiService.Init();
            
            _uiService.Show<MainMenu>();
        }
    }
}