using System;
using FallObject;
using UnityEngine;

public class PlayerHpController
{
    public Action<float> OnHealthChanged;

    public Action OnZeroHealth;
        
    private float _health;
        
    public PlayerHpController(float health)
    {
        _health = health;

        FallObjectController.DamageToPlayerNotify += ReduceHealth;
    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        if (_health > 0)
        {
            OnHealthChanged?.Invoke(_health);
        }
        else
        {
            OnZeroHealth?.Invoke();
        }
    }
}