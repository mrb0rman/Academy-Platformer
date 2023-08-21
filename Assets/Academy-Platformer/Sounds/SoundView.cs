using UnityEngine;

namespace Academy_Platformer.Sounds
{
    public class SoundView : MonoBehaviour
    {
        public AudioSource AudioSource => audioSource;

        [SerializeField] private AudioSource audioSource;
    }
}