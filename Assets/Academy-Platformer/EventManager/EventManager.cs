using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action UpdateEventHandler;
    public static event Action FixedUpdateEventHandler;

    private void Update()
    {
        UpdateEventHandler?.Invoke();
    }

    private void FixedUpdate()
    {
        FixedUpdateEventHandler?.Invoke();
    }
}