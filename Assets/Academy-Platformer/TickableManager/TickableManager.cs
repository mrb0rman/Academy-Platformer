using System;
using UnityEngine;

public class TickableManager : MonoBehaviour
{
    public static event Action UpdateEventHandler;
    public static event Action FixedUpdateEventHandler;
    
    void Update()
    {
        UpdateEventHandler?.Invoke();
    }
    void FixedUpdate()
    {
        FixedUpdateEventHandler?.Invoke();
    }
}
