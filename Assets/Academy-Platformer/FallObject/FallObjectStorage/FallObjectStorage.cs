using System.Collections;
using System.Collections.Generic;
using Academy_Platformer.FallObject;
using Unity.VisualScripting;
using UnityEngine;

public class FallObjectStorage
{
    public int StorageCount => _storage.Count;
    
    private List<FallObjectView> _storage = new List<FallObjectView>();

    public void Add(FallObjectView fallObjectView)
    {
        if (fallObjectView == null)
        {
            Debug.LogError("[FallObjectStorage.Add] Fall object is null");
            return;
        }
        
        _storage.Add(fallObjectView);
    }

    public FallObjectView Get(int index)
    {
        if (index >= StorageCount || index < 0)
        {
            Debug.LogError("[FallObjectStorage.Get] Index is out of range");

            return null;
        }

        return _storage[index];
    }

    public void Delete(int index)
    {
        if (index >= StorageCount || index < 0)
        {
            Debug.LogError("[FallObjectStorage.Delete] Index is out of range");

            return;
        }

        _storage.Remove(Get(index));
    }
}
