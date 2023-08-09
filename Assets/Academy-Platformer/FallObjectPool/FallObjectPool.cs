using System.Collections.Generic;
using Academy_Platformer.FallObject;
using UnityEngine;

public class FallObjectPool
{
    private FallObjectController _fallObjectController;

    private List<FallObjectView> _pool;

    private Transform _container;

    public FallObjectPool(
        Transform container, 
        FallObjectController controller)
    {
        _fallObjectController = controller;
        _container = container;
        _pool = new List<FallObjectView>();
    }

    public FallObjectView CreateObject(FallObjectType type)
    {
        var freeObject = GetFreeElement();

        if (freeObject)
        {
            return freeObject;
        }
        
        var createdObject = _fallObjectController.CreateObject(type);
        _pool.Add(createdObject);

        return createdObject;
    }

    private FallObjectView GetFreeElement()
    {
        foreach (var fallObject in _pool)
        {
            if (!fallObject.gameObject.activeInHierarchy)
            {
                fallObject.gameObject.SetActive(true);
                return fallObject;
            }
        }
        
        return null;
    }
}
