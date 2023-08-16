using System;
using Academy_Platformer.FallObject;
using Academy_Platformer.FallObject.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallObjectSpawner
{
    public FallObjectPool Pool => _pool;
    
    private Transform[] _spawnPoints;
    private FallObjectPool _pool;

    private float _spawnPeriodMin;
    private float _spawnPeriodMax;
    private float _spawnPeriod;
    private int _typesCount;

    public FallObjectSpawner(
        Transform[] spawnPoints, 
        float spawnPeriodMin, 
        float spawnPeriodMax)
    {
        _spawnPoints = spawnPoints;
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
            SpawnNewObject(Random.Range(0, _spawnPoints.Length));
            _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
        }
    }

    private void SpawnNewObject(int spawnPoint)
    {
        var type = Random.Range(0, _typesCount);
        var newObject = _pool.CreateObject((FallObjectType)type);
        newObject.gameObject.transform.position = _spawnPoints[spawnPoint].position;
        newObject.OnDeathEvent += _pool.ReturnToPool;
    }
}
