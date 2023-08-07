using System.Collections;
using System.Collections.Generic;
using Academy_Platformer.FallObject;
using Unity.VisualScripting;
using UnityEngine;

public class FallObjectStorage
{
    private Dictionary<FallObjectType, FallObjectController> _controllers;
    private Dictionary<FallObjectType, FallObjectView[]> _storage;

    public FallObjectStorage()
    {
        _storage = new Dictionary<FallObjectType, FallObjectView[]>();
        _controllers = new Dictionary<FallObjectType, FallObjectController>()
        {
            { FallObjectType.Type1, new FallObjectController() },
            { FallObjectType.Type2, new FallObjectController() },
        };
    }

    public void Add(FallObjectType type)
    {
        
    }

    public void Get()
    {
        
    }

    public void Delete()
    {
        
    }
}
