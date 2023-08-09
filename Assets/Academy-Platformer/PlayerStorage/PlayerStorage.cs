using System.Collections.Generic;
using FactoryPlayer;
using UnityEngine;

namespace PlayerStorage
{
    public class PlayerStorage
    {
        private List<PlayerView> _listObject = new List<PlayerView>();

        public void Add(PlayerView playerView)
        {
            if (playerView == null)
            {
                Debug.Log($"Component {playerView} is null");
                
                return;
            }

            if (_listObject.Contains(playerView))
            {
                Debug.Log($"Component {playerView} has already been written to the list");
                
                return;
            }
            
            _listObject.Add(playerView);
        }

        public void Delete(PlayerView playerView)
        {
            if (!_listObject.Contains(playerView))
            {
                Debug.Log($"The component {playerView} is not in the list"); 
                
                return;
            }
            
            Object.Destroy(playerView);
            
            _listObject.Remove(playerView);
        }
    }
}