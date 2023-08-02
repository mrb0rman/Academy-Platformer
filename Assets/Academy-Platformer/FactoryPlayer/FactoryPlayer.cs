using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class FactoryPlayer : IFactoryCharacter
    {
        private PlayerConfig _playerConfig;
        private PlayerView _playerPrefab;
        
        public FactoryPlayer()
        {
            _playerConfig = Resources.Load<PlayerConfig>(path: "PlayerConfig");
        }
        
        public PlayerView Create()
        {
            var player = GameObject.Instantiate(_playerPrefab);
            var model = _playerConfig.Get();
            player.health = model.health;
            player.speed = model.speed;
            return player;
        }
    }
}