using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoundPool
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig", order = 2)]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] public SoundModel[] soundModel;
        
        [NonSerialized] private bool _inited;

        private Dictionary<string, SoundModel> _dictSound = new Dictionary<string, SoundModel>();

        public SoundModel Get(string nameSound)
        {
            if (!_inited)
            {
                Init();
                _inited = !_inited;
            }

            if (!_dictSound.ContainsKey(nameSound))
            {
                Debug.Log($"Sound named {nameSound} not found.");
            }
            return _dictSound[nameSound];
        }
        
        private void Init()
        {
            foreach (var sound in soundModel)
            {
                _dictSound.Add(sound.NameSound, sound);
            }
        }
    }

    [Serializable]
    public struct SoundModel
    {
        public string NameSound;
        
        public AudioClip Sound;
    }
}