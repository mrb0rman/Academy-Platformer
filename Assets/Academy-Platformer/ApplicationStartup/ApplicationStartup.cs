using Bootstrap;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        
        private void Start()
        {
            Destroy(gameObject);
        }
        
        private void NotifyOfCompletion()
        {
            Debug.Log("The end");
        }
        
    }
}