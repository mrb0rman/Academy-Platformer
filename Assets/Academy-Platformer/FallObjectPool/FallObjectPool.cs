using System.Collections;
using System.Collections.Generic;
using Academy_Platformer.FallObject;
using Unity.VisualScripting;
using UnityEngine;

public class FallObjectPool
{
    public int PoolCount => _pool.Count;
    
    private FallObjectController _fallObjectController;

    private List<FallObjectView> _pool;

    private Transform _container;

    public FallObjectPool(Transform container, FallObjectController controller)
    {
        _fallObjectController = controller;
        _container = container;
        _pool = new List<FallObjectView>();
    }

    private FallObjectView CreateObject(bool setToActive = false)
    {
        var createdObject = CreateRandomObject();
        createdObject.gameObject.SetActive(setToActive);
        _pool.Add(createdObject);

        return createdObject;
    }

    private FallObjectView CreateRandomObject()
    {
        var random = Random.Range(0, 2);

        if (random == 0)
        {
            return _fallObjectController.CreateObject(FallObjectType.Type1);
        }

        return _fallObjectController.CreateObject(FallObjectType.Type2);
    }

    private bool TryGetFreeElement(out FallObjectView element)
    {
        foreach (var fallObject in _pool)
        {
            if (!fallObject.gameObject.activeInHierarchy)
            {
                fallObject.gameObject.SetActive(true);
                element = fallObject;
                return true;
            }
        }

        element = null;
        return false;
    }

    public FallObjectView Get()
    {
        if (TryGetFreeElement(out var element))
            return element;

        var newObject = CreateObject();
        return newObject;
    }
}
