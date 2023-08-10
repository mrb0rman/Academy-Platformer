using System.Collections.Generic;
using Academy_Platformer.FallObject;
using UnityEngine;

public class FallObjectPool
{
    private FallObjectController _fallObjectController;
    private TickableManager _tickableManager;

    private List<FallObjectView> _pool;

    public FallObjectPool(FallObjectController controller, TickableManager tickableManager)
    {
        _fallObjectController = controller;
        _tickableManager = tickableManager;
        _pool = new List<FallObjectView>();
    }

    public FallObjectView CreateObject(FallObjectType type)
    {
        var freeObject = GetFreeElement();

        if (freeObject)
        {
            return freeObject;
        }
        
        var createdObject = _fallObjectController.CreateObject(type, _tickableManager);
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

    public void ReturnToPool(FallObjectView fallObject)
    {
        var objectToReturn = _pool.Find(i => i == fallObject);

        if (!objectToReturn)
        {
            Debug.Log("There is no such object in pool");
            return;
        }

        objectToReturn.gameObject.SetActive(false);
    }
}
