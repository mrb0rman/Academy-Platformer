namespace Sounds
{
    public class SoundController
    {
        private SoundPool _soundPool;

        public SoundController()
        {
            _soundPool = new SoundPool();
        }
        
        public void Play(SoundName soundName)
        {
            SwitchOff();
            
            var sound = _soundPool.TakeFromPool(soundName);
            sound.AudioSource.Play();
        }

        public void SwitchOff()
        {
            _soundPool.DisableCompletedSounds();
        }

        public void Stop()
        {
            _soundPool.MuteSound();
        }
    }
}