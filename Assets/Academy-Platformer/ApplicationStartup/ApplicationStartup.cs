using System;
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
            CreateScene();
        }

        private void CreateScene()
        {
            CreateGameObject(ResourcesConst.ResourcesConst.EventMananger);
        }

        private GameObject CreateGameObject(string resourcesConst)
        {
            var prefab = Resources.Load<GameObject>(resourcesConst);
            var gameObject = GameObject.Instantiate(prefab);
            return gameObject; 
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