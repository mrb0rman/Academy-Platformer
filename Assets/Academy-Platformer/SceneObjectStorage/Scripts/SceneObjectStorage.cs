using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class SceneObjectStorage : ISceneObjectStorage
{
    private List<GameObject> _storage = new List<GameObject>();

    public GameObject Create(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        if (prefab is null)
        {
            return null;
        }

        var gameObject = GameObject.Instantiate(prefab);
        Add(gameObject);
        return gameObject;
    }

    public void Add(GameObject gameObject)
    {
        if (!_storage.Contains(gameObject))
        {
            _storage.Add(gameObject);
        }
    }

    public void Delete(GameObject gameObject)
    {
        if (!_storage.Contains(gameObject))
        {
            Debug.LogError("storage don't contains gameObject");
        }

        GameObject.Destroy(gameObject);
        _storage.Remove(gameObject);
    }
}