using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Academy_Platformer.FallObject
{
    public class FallObjectSpawner
    {
        public FallObjectPool Pool => _pool;
    
        private float _minPositionX;
        private float _maxPositionX;
        private FallObjectPool _pool;

        private float _spawnPeriodMin;
        private float _spawnPeriodMax;
        private float _spawnPeriod;
        private int _typesCount;

        public FallObjectSpawner(
            float minPositionX,
            float maxPositionX,
            float spawnPeriodMin, 
            float spawnPeriodMax)
        {
            _minPositionX = minPositionX;
            _maxPositionX = maxPositionX;
            _spawnPeriodMin = spawnPeriodMin;
            _spawnPeriodMax = spawnPeriodMax;
        
            _pool = new FallObjectPool(new FallObjectFactory());
            _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
            _typesCount = Enum.GetValues(typeof(FallObjectType)).Length;
        }

        public void Update()
        {
            _spawnPeriod -= Time.deltaTime;

            if (_spawnPeriod <= 0)
            {
                SpawnNewObject();
                _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
            }
        }

        private void SpawnNewObject()
        {
            var type = Random.Range(0, _typesCount);
            var newObject = _pool.CreateObject((FallObjectType)type);
            newObject.gameObject.transform.position = new Vector3(Random.Range(_minPositionX, _maxPositionX),0,0);
            newObject.OnDeathEvent += _pool.ReturnToPool;
        }
    }
}