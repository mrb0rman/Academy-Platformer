using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

public class SceneObjectStorage : ISceneObjectStorage
{
    private Dictionary<Type, Object> _storage = new();
    public Object Create<T>(string path) where T : Object
    {
        var prefab = Resources.Load<T>(path);
        if (prefab is null)
        {
            Debug.LogError($"prefab is null {path}");
            return null;
        }
        if (_storage.Keys.Contains(typeof(T)))
        {
            Debug.LogError($"This Item already created: {prefab}");
            return _storage[typeof(T)];
        }
        var obj = Object.Instantiate(prefab);
        if (_storage.TryAdd(typeof(T), obj))
        {
            return obj;
        }
        else
        {
            Debug.Log($"Item {prefab} doesn't adding to dictionary");
        }
        return null;
    }

    public bool Add<T>(T Object) where T : Object
    {
        if (_storage.TryAdd(typeof(T), Object))
        {
            return true;
        }
        else
        {
            Debug.LogError($"Item not added:{Object}");
            return false;
        }
    }

    public void Delete<T>() where T : Object
    {
        if (!_storage.Remove(typeof(T)))
        {
            Debug.LogError($"Item not removed Key(Type): {typeof(T)}");
        }
    }
}