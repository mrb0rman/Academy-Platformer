using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _musicSources;
    [SerializeField] private AudioSource[] _effectSources;

    public void PlaySound(AudioClip clip)
    {
        // select an audio source and call the Play() method
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
