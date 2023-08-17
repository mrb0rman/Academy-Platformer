using System;
using System.Collections.Generic;
using UnityEngine;

namespace Academy_Platformer.SoundMVC
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig", order = 1)]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] private SoundModels[] soundModels;
        private Dictionary<string, AudioClip> _dict = new();
        private bool _inited;

        private void Init()
        {
            foreach (var model in soundModels)
                _dict.Add(model.Name, model.Clip);
        }

        public AudioClip Get(string name)
        {
            if (!_inited)
                Init();

            return _dict[name];
        }
    }

    [Serializable]
    public struct SoundModels
    {
        public string Name;
        public AudioClip Clip;
    }
}