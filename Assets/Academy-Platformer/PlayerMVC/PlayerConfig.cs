﻿using System;
using UnityEngine;

namespace FactoryPlayer
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    
    public class PlayerConfig : ScriptableObject
    {
        public PlayerModel PlayerModel => playerModel;
        
        [SerializeField] private PlayerModel playerModel;
    }

    [Serializable]
    public struct PlayerModel
    {
        public int Health;
        public int Speed;
        public Sprite Sprite;
    }
}