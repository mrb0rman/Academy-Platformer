using System.Collections;
using UnityEngine;

namespace Academy_Platformer.SoundMVC
{
    public class SoundController
    {
        private SoundConfig _soundConfig;
        private SoundView _soundView;
        private AudioSource _audioSource;

        public SoundController()
        {
            var soundManager = Resources.Load<SoundView>(ResourcesConst.ResourcesConst.SoundManager);
            _soundView = Object.Instantiate(soundManager);
            _audioSource = _soundView.GetComponent<AudioSource>();
            _soundConfig = Resources.Load<SoundConfig>(ResourcesConst.ResourcesConst.SoundConfig);
        }

        IEnumerator Play(SoundName soundName)
        {
            _audioSource.clip = _soundConfig.Get(soundName);
            
            _audioSource.Play();
            yield return new WaitForSeconds(_audioSource.clip.length);
            _audioSource.clip = null;
        }
    }
}