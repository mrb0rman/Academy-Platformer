﻿using UnityEngine;

namespace SoundPool
{
    public class SoundView : MonoBehaviour
    {
        public AudioSource AudioSource => audioSource;

        [SerializeField] private AudioSource audioSource;
    }
}