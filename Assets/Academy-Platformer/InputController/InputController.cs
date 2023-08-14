using System;
using UnityEngine;

public class InputController
{
    public event Action OnLeftEvent;
    public event Action OnRightEvent;

    public InputController(TickableManager tickableManager)
    {
        tickableManager.UpdateEventHandler += CheckInput;
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            OnLeftEvent?.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            OnRightEvent?.Invoke();
    }
}