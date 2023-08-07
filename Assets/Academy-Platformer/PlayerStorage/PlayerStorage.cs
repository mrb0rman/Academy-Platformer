using FactoryPlayer;
using UnityEngine;

namespace PlayerStorage
{
    public class PlayerStorage
    {
        public PlayerView PlayerView
        {
            get
            {
                if (_playerView == null)
                {
                    Debug.LogError("Player is null");
                }
                
                return _playerView;
            }
            set
            {
                if(value == null)
                {
                    Debug.LogError("Player is null");
                
                    return;
                }

                _playerView = value;
            }
        }

        private PlayerView _playerView;

        public void Delete()
        {
            if(PlayerView == null)
            {
                Debug.LogError("Player is null");
                
                return;
            }

            Object.Destroy(PlayerView);
        }
    }
}