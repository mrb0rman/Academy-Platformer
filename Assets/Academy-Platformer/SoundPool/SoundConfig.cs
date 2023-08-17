using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoundPool
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig", order = 2)]
    public class SoundConfig : ScriptableObject
    {
        
    }

    [Serializable]
    public struct SoundModel
    {
        public AudioSource Sound;
        
        public string nameSound;
    }
}