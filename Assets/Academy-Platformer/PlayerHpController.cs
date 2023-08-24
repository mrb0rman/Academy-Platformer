using System;

namespace Academy_Platformer
{
    public class PlayerHpController
    {
        public Action<float> OnHealthChanged;

        public Action OnZeroHealth;
        
        private float _health;
        
        public PlayerHpController(float health)
        {
            _health = health;
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
}