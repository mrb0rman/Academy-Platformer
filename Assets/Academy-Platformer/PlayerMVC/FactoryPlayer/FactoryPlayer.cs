using Interface;
using UnityEngine;

namespace FactoryPlayer
{
    public class FactoryPlayer : IFactoryCharacter
    {
        private PlayerView _playerPrefab;

        public FactoryPlayer()
        {
            _playerPrefab = Resources.Load<PlayerView>(ResourcesConst.ResourcesConst.PlayerPrefab);
        }
        
        public PlayerView Create(PlayerModel playerModel, PlayerView playerView)
        {
            playerView = GameObject.Instantiate(_playerPrefab);
            playerView.SpriteRenderer.sprite = playerModel.Sprite;
            
            return playerView;
        }
    }
}