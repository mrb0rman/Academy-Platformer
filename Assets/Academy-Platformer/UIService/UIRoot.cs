using UnityEngine;

namespace UIService
{
    public class UIRoot : MonoBehaviour
    {
        public Transform ActivateContainer => activateContainer;
        public Transform DeactivateContainer => deactivateContainer;
        
        [SerializeField] private Transform activateContainer;
        [SerializeField] private Transform deactivateContainer;
    }
}