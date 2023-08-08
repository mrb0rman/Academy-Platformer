using System.Collections.Generic;
using FactoryPlayer;
using UnityEngine;

namespace PlayerStorage
{
    public class PlayerStorage
    {
        private Dictionary<int, PlayerView> _dictObject = new Dictionary<int, PlayerView>();

        public void Add(PlayerView playerView)
        {
            if (playerView == null)
            {
                Debug.Log($"Component {playerView} is null");
                
                return;
            }

            if (_dictObject.ContainsKey(playerView.GetInstanceID()))
            {
                Debug.Log($"Component {playerView} has already been written to the dictionary");
                
                return;
            }
            
            _dictObject.Add(playerView.GetInstanceID(), playerView);
        }

        public PlayerView Get(int id)
        {
            if (!_dictObject.ContainsKey(id))
            {
                Debug.Log($"The component with this id = {id} is not in the dictionary"); 
                
                return null;
            }

            return _dictObject[id];
        }
        
        public void Delete(int id)
        {
            if (!_dictObject.ContainsKey(id))
            {
                Debug.Log($"The component with this id = {id} is not in the dictionary"); 
                
                return;
            }
            
            Object.Destroy(_dictObject[id]);
            
            _dictObject.Remove(id);
        }
    }
}