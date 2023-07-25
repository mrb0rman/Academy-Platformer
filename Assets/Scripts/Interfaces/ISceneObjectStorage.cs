using UnityEngine;

namespace Interfaces
{
    public interface ISceneObjectStorage
    {
        
        GameObject Create(string path);
        void Add(GameObject gameObject);
        void Delete(GameObject gameObject);
    }
}
