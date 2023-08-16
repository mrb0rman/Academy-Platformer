using System;
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
        }

        private void Play(String soundName)
        {
            var playingSound = Resources.Load<AudioClip>(soundName);
            _audioSource.clip = playingSound;
        }
    }
}