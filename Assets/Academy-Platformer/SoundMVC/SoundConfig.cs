using System;
using UnityEngine;

namespace Academy_Platformer.SoundMVC
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig", order = 1)]
    public class SoundConfig : ScriptableObject
    {
        public SoundModel SoundModel => soundModel;
        [SerializeField] private SoundModel soundModel;
    }

    [Serializable]
    public struct SoundModel
    { }
}