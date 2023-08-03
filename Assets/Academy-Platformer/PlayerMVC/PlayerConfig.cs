using System;
using UnityEngine;

namespace FactoryPlayer
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private PlayerModel player;

        public PlayerModel Get()
        {
            return player;
        }
    }

    [Serializable]
    public struct PlayerModel
    {
        public int Health;
        public int Speed;
        public Sprite Sprite;
    }
}