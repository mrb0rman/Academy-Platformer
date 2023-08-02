using System;
using UnityEngine;

namespace FactoryPlayer
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Player player;

        public Player Get()
        {
            return player;
        }
    }

    [Serializable]
    public struct Player
    {
        public int health;
        public int speed;
    }
}