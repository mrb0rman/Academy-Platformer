using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class SceneObjectStorage : ISceneObjectStorage
{
    private List<GameObject> _storage = new();
    private Dictionary<string, GameObject> _prefabs = new();

    public GameObject Create(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        if (prefab is null)
        {
            Debug.LogError($"prefab is null {path}");
            return null;
        }

        if (_prefabs.TryAdd(path, prefab))
        {
            var gameObject = GameObject.Instantiate(prefab);
            Add(gameObject);
            return gameObject;
        }
        else
        {
            Debug.LogError($"This Item already created: {prefab}");
        }

        return null;
    }

    public bool Add(GameObject gameObject)
    {
        if (!_storage.Contains(gameObject))
        {
            _storage.Add(gameObject);
            return true;
        }
        else
        {
            Debug.LogError($"The storage already has this item:{gameObject}");
        }

        return false;
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