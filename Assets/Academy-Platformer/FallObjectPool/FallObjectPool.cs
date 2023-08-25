using System.Collections.Generic;
using Academy_Platformer.FallObject;
using Academy_Platformer.FallObject.Factory;
using UnityEngine;

public class FallObjectPool
{
    private FallObjectFactory _factory;

    private Dictionary<FallObjectView, FallObjectController> _pool;

    private GameObject _container; 

    public FallObjectPool(FallObjectFactory factory)
    {
        _factory = factory;
        _pool = new Dictionary<FallObjectView, FallObjectController>();
        _container = new GameObject("FallObjects");
    }

    public FallObjectView CreateObject(FallObjectType type)
    {
        var freeObject = GetFreeElement();

        if (freeObject)
        {
            return freeObject;
        }
        
        var controller = _factory.Create(type);
        var view = controller.View;
        
        controller.SetActive(true);
        view.transform.parent = _container.transform;
        
        _pool.Add(view, controller);

        return view;
    }

    private FallObjectView GetFreeElement()
    {
        foreach (var fallObjectController in _pool.Values)
        {
            if (!fallObjectController.View.gameObject.activeInHierarchy)
            {
                fallObjectController.SetActive(true);
                return fallObjectController.View;
            }
        }
        
        return null;
    }

    public void ReturnToPool(FallObjectView fallObject)
    {
        if (_pool.TryGetValue(fallObject, out var controller))
        {
            controller.SetActive(false);
        }
        else
        {
            Debug.Log("There is no such object in pool");
            return;
        }
    }

    public FallObjectController GetController(FallObjectView view)
    {
        return _pool[view];
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
