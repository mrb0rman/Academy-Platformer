using UnityEngine;

namespace DefaultNamespace
{
    public class UIRoot
    {
        [SerializeField] private Transform _activateContainer;
        
        [SerializeField] private Transform _deactivateContainer;

        public Transform activateContainer => _activateContainer;

        public Transform deactivateContainer => _deactivateContainer;
    }
}