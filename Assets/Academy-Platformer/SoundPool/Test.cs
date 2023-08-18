using System;
using UnityEngine;

namespace SoundPool
{
    public class Test : MonoBehaviour
    {
        private SoundPool _soundPool;
        private AudioSource _source;
        private void Start()
        {
            _soundPool = new SoundPool();
            _soundPool.TakeFromPool("Back","BackStart", 0.5f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _soundPool.TakeFromPool("Back","StartGame");
            } else if (Input.GetKeyDown(KeyCode.G))
            {
                _soundPool.TakeFromPool("Back","BackMain", 0.5f);
            } else if (Input.GetKeyDown(KeyCode.H))
            {
                _soundPool.TakeFromPool("Buff","Buff1");
            } else if (Input.GetKeyDown(KeyCode.J))
            {
                _soundPool.TakeFromPool("Buff","Buff2");
            }
            _soundPool.ReturnToPool();
        }
    }
}