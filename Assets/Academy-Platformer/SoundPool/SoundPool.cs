using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SoundPool
{
    public class SoundPool
    {
        private SoundView _soundView;
        private List<SoundView> _listSoundViews;
        private SoundPoolView _soundPoolView;
        private SoundConfig _soundConfig;

        public SoundPool()
        {
            _listSoundViews = new List<SoundView>();
            
            _soundView = Resources.Load<SoundView>(ResourcesConst.ResourcesConst.SoundView);
            _soundPoolView = Object.Instantiate(Resources.Load<SoundPoolView>(ResourcesConst.ResourcesConst.SoundPoolView));
            _soundConfig = Resources.Load<SoundConfig>(ResourcesConst.ResourcesConst.SoundConfig);
        }

        public SoundView TakeFromPool(string nameSound, float volume = 1)
        {
            var sound = _listSoundViews[SearchingEmptySoundView()];
            
            sound.gameObject.SetActive(true);
            sound.AudioSource.clip = _soundConfig.Get(nameSound).Sound;
            sound.AudioSource.volume = volume;
            
            sound.AudioSource.Play();

            return sound;
        }

        public void DisablingCompletedSound()
        {
            foreach (var soundView in _listSoundViews)
            {
                if (!soundView.AudioSource.isPlaying)
                {
                    soundView.AudioSource.clip = null;
                    soundView.gameObject.SetActive(false);
                }
            }
        }
        
        private void CreateSoundView()
        {
            _listSoundViews.Add(Object.Instantiate(_soundView, _soundPoolView.transform));
        }

        private int SearchingEmptySoundView()
        {
            for (int i = 0; i < _listSoundViews.Count; i++)
            {
                if (!_listSoundViews[i].AudioSource.isPlaying)
                {
                    return i;
                }
            }

            CreateSoundView();
            
            return _listSoundViews.Count - 1;
        }
        
    }
}