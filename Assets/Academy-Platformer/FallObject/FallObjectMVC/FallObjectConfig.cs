using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Academy_Platformer.FallObject
{
    [CreateAssetMenu(fileName = "FallObjectConfig", menuName = "Configs/FallObjectConfig")]
    public class FallObjectConfig : ScriptableObject
    {
        [SerializeField] private FallObjectModel[] _fallObjectModels;
        
        private Dictionary<FallObjectType, FallObjectModel> _dict = new Dictionary<FallObjectType, FallObjectModel>();
        
        [NonSerialized] private bool _inited;

        private void Init()
        {
            _inited = true;
            
            foreach (var model in _fallObjectModels)
            {
                _dict.Add(model.Type, model);
            }
        }

        public FallObjectModel Get(FallObjectType type)
        {
            if (!_inited)
            {
                Init();
            }

            return _dict[type];
        }
    }

    public enum FallObjectType
    {
        Type1,
        Type2
    }

    [Serializable]
    public struct FallObjectModel
    {
        public FallObjectType Type;
        public int PointsPerObject;
        public int Damage;
        public Sprite ObjectSprite;
    }
}