using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class FactoryPlayer : IFactoryCharacter
    {
        private PlayerConfig _playerConfig;
        private PlayerView _playerPrefab;

        public FactoryPlayer(PlayerConfig playerConfig)
        {
            _playerPrefab = Resources.Load<PlayerView>("Player");
            _playerConfig = playerConfig;
        }
        
        public PlayerView Create()
        {
            var player = GameObject.Instantiate(_playerPrefab);
            var model = _playerConfig.Get();
            player.SpriteRenderer.sprite = model.Sprite;
            return player;
        }
    }
}