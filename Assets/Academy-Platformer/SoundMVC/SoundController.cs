using System.Collections;
using UnityEngine;

namespace Academy_Platformer.SoundMVC
{
    public class SoundController
    {
        private SoundConfig _soundConfig;
        private SoundView _soundView;
        private AudioSource _audioSource;

        public SoundController(SoundView soundView)
        {
            _soundView = soundView;
            _soundConfig = Resources.Load<SoundConfig>(ResourcesConst.ResourcesConst.SoundConfig);
            _audioSource = _soundView.GetComponent<AudioSource>();

            _soundView.StartCoroutine(Play("StartGame"));
        }

        IEnumerator Play(string soundName)
        {
            _audioSource.clip = _soundConfig.Get(soundName);
            
            _audioSource.Play();
            yield return new WaitForSeconds(_audioSource.clip.length);
            _audioSource.clip = null;
        }
    }
}