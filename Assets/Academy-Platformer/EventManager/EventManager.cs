using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action UpdateEventHandler;
    public event Action FixedUpdateEventHandler;
    
    private void Update()
    {
        UpdateEventHandler?.Invoke();
    }
    
    private void FixedUpdate()
    {
        FixedUpdateEventHandler?.Invoke();
    }
}