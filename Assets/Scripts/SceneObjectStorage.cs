using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class SceneObjectStorage : ISceneObjectStorage
{
    private List<GameObject> storage = new List<GameObject>();

    public GameObject Create(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        if (prefab is null)
            return null;
        var gameObject = GameObject.Instantiate(prefab);
        return gameObject;
    }

    public void Add(GameObject gameObject)
    {
        storage.Add(gameObject);
    }

    public void Delete(GameObject gameObject)
    {
        GameObject.Destroy(gameObject);
        storage.Remove(gameObject);
    }
}