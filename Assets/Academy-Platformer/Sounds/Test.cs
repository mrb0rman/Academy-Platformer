using UnityEngine;

namespace Academy_Platformer.Sounds
{
    public class Test : MonoBehaviour
    {
        private SoundController _soundController;
        
        private void Start()
        {
            _soundController = new SoundController();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _soundController.Play(SoundName.Buff1, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _soundController.Play(SoundName.Buff2, 0.5f);
            }
            
            _soundController.SwitchOff();
        }
    }
}