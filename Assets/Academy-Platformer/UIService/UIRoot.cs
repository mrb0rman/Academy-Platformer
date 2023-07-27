using UnityEngine;

namespace UIServiceNamespace
{
    public class UIRoot : MonoBehaviour
    {
        public Transform activateContainer => _activateContainer;
        public Transform deactivateContainer => _deactivateContainer;
        
        [SerializeField] private Transform _activateContainer;
        [SerializeField] private Transform _deactivateContainer;
    }
}