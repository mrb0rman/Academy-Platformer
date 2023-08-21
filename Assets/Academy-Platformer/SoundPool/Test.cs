using System;
using UnityEngine;

namespace SoundPool
{
    public class Test : MonoBehaviour
    {
        private SoundPool _soundPool;
        
        private void Start()
        {
            _soundPool = new SoundPool();
            _soundPool.TakeFromPool("BackStart", 0.5f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _soundPool.TakeFromPool("Buff1");
            }

            _soundPool.DisablingCompletedSound();
        }
    }
}