using UnityEngine;

namespace Interfaces
{
    public interface ISceneObjectStorage
    {
        Object Create<T>(string path)where T : Object;
        bool Add<T>(T gameObject)where T : Object;
        void Delete<T>() where T : Object;
    }
}
