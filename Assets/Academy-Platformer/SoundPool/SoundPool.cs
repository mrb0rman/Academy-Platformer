using System.Collections.Generic;
using UnityEngine;

namespace SoundPool
{
    public class SoundPool
    {
        private Dictionary<string, AudioSource> _dictSound;

        public SoundPool() 
        {
            _dictSound = new Dictionary<string, AudioSource>();
        }

        public AudioSource TakeFromPool(string nameSound)
        {
            if (!_dictSound.ContainsKey(nameSound))
            {
                Debug.Log($"Sound with the name {nameSound} not found");
                return null;
            }
            
            return _dictSound[nameSound];
        }
    }
}