using System.Collections.Generic;
using Academy_Platformer.FallObject;
using Academy_Platformer.FallObject.Factory;
using UnityEngine;

public class FallObjectPool
{
    private FallObjectFactory _factory;

    private Dictionary<FallObjectView, FallObjectController> _pool;

    public FallObjectPool(FallObjectFactory factory)
    {
        _factory = factory;
        _pool = new Dictionary<FallObjectView, FallObjectController>();
    }

    public FallObjectView CreateObject(FallObjectType type)
    {
        var freeObject = GetFreeElement();

        if (freeObject)
        {
            return freeObject;
        }
        
        var value = _factory.Create(type);
        var key = value.View;
        _pool.Add(key, value);

        return key;
    }

    private FallObjectView GetFreeElement()
    {
        foreach (var fallObject in _pool.Keys)
        {
            if (!fallObject.gameObject.activeInHierarchy)
            {
                fallObject.gameObject.SetActive(true);
                return fallObject;
            }
        }
        
        return null;
    }

    public void ReturnToPool(FallObjectView fallObject)
    {
        if (_pool.TryGetValue(fallObject, out var controller))
        {
            controller.View.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("There is no such object in pool");
            return;
        }
    }

    public void AllReturnToPool()
    {
        foreach (var fallObject in _pool.Keys)
        {
            if (fallObject.gameObject.activeInHierarchy)
            {
                ReturnToPool(fallObject);
            }
        }
    }
}
