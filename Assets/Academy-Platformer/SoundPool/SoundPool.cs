using System.Collections.Generic;
using UnityEngine;

namespace SoundPool
{
    public class SoundPool
    {
        private SoundConfig _soundConfig;
        
        private Dictionary<string, AudioSource> _dictSound;

        public SoundPool() 
        {
            _dictSound = new Dictionary<string, AudioSource>(); 
            
            _soundConfig = Resources.Load<SoundConfig>(ResourcesConst.ResourcesConst.SoundConfig);
        }

        public AudioSource TakeFromPool(string nameSource, string nameSound, float volume = 1)
        {
            if (!_dictSound.ContainsKey(nameSource))
            {
                CreateAudioSource(nameSource, nameSound, volume);
            }
            
            SetSound(nameSource, nameSound, volume);
            
            _dictSound[nameSource]?.Play();
                
            return _dictSound[nameSource];
        }

        public void ReturnToPool()
        {
            foreach (var source in _dictSound)
            {
                if (!source.Value.isPlaying)
                {
                    source.Value.clip = null; 
                }
            }
        }
        
        private void CreateAudioSource(string nameSource, string nameSound, float volume)
        {
            var audio = Object.Instantiate(Resources.Load<AudioSource>(ResourcesConst.ResourcesConst.SoundManager));
            audio.clip = _soundConfig.Get(nameSound).Sound;
            audio.volume = volume;
            
            _dictSound.Add(nameSource, audio);
        }

        private void SetSound(string nameSource, string nameSound, float volume)
        {
            _dictSound[nameSource].clip = _soundConfig.Get(nameSound).Sound;
            _dictSound[nameSource].volume = volume;
        }
    }
}