using System.Collections.Generic;
using FactoryPlayer;
using UnityEngine;

namespace PlayerStorage
{
    public class PlayerStorage
    {
        private Dictionary<int, Component> _dictObject = new Dictionary<int, Component>();

        public void Add(Component playerView)
        {
            if (playerView == null)
            {
                Debug.LogError($"Component {playerView} is null");
                return;
            }

            if (_dictObject.ContainsKey(playerView.GetInstanceID()))
            {
                Debug.LogError($"Component {playerView} has already been written to the dictionary");
                return;
            }
            
            _dictObject.Add(playerView.GetInstanceID(), playerView);
        }

        public T Get<T>(int id) where T: Component
        {
            if (!_dictObject.ContainsKey(id))
            {
                Debug.LogError($"the component with this id = {id} is not in the dictionary"); 
                
                return null;
            }

            return (T)_dictObject[id];
        }
        
        public void Delete(int id)
        {
            if (!_dictObject.ContainsKey(id))
            {
                Debug.LogError($"the component with this id = {id} is not in the dictionary"); 
                
                return;
            }
            
            Object.Destroy(_dictObject[id]);
            
            _dictObject.Remove(id);
        }
    }
}