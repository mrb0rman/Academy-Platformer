using System;
using UnityEngine;

public class TickableManager : MonoBehaviour
{
    public static event Action UpdateNotify;
    public static event Action FixedUpdateNotify;
    
    void Update()
    {
        UpdateNotify?.Invoke();
    }
    void FixedUpdate()
    {
        FixedUpdateNotify?.Invoke();
    }
}
