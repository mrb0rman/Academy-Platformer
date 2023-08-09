using Bootstrap;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();

        private void Start()
        {
            StartBootstrap();
            Create<TickableManager>(ResourcesConst.ResourcesConst.TickableManager);
        }
        
        private T Create<T>(string resourcesConst) where T: Object
        {
            var prefab = Resources.Load<T>(resourcesConst);
            var obj = Instantiate(prefab);
            return obj; 
        }

        private void StartBootstrap()
        {
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
        }

        private void NotifyOfCompletion()
        { }
    }
}