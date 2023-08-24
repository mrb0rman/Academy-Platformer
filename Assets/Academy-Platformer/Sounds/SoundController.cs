using UnityEngine;

namespace Academy_Platformer.Sounds
{
    public class SoundController
    {
        private SoundPool _soundPool;

        public SoundController()
        {
            _soundPool = new SoundPool();
            TickableManager.UpdateNotify += CheckInput;
        }

        private void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Play(SoundName.Buff1, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Play(SoundName.Debuff1, 0.5f);
            }
            
            SwitchOff();
        }
        
        public void Play(SoundName soundName, float volume)
        {
            var sound = _soundPool.TakeFromPool(soundName, volume);
            sound.AudioSource.Play();
        }

        public void SwitchOff()
        {
            _soundPool.DisableCompletedSounds();
        }
    }
}