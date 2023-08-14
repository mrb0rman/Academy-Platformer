using System;

namespace Academy_Platformer.HPController
{
    public class HPController
    {
        public Action<float> OnHealthChanged;

        public Action OnZeroHealth;
        
        private float _health;
        
        public HPController(float health)
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