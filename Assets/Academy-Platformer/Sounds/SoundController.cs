namespace Academy_Platformer.Sounds
{
    public class SoundController
    {
        private SoundPool _soundPool;

        public SoundController()
        {
            _soundPool = new SoundPool();
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