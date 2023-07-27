using UnityEngine;

namespace Interfaces
{
    public interface ISceneObjectStorage
    {
        GameObject Create(string path);
        bool Add(GameObject gameObject);
        void Delete(GameObject gameObject);
    }
}
