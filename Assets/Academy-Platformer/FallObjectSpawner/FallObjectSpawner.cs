using System;
using System.Collections.Generic;
using Academy_Platformer.FallObject;
using Academy_Platformer.FallObject.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallObjectSpawner
{
    public FallObjectPool Pool => _pool;
    
    private Transform[] _spawnPoints;
    private FallObjectPool _pool;

    private const float _spawnPeriodMin = 1f;
    private const float _spawnPeriodMax = 4f;
    private float _spawnPeriod;
    private int _typesCount;

    public FallObjectSpawner()
    {
        List<Transform> spawnPointList = new();
        var SpawnPointsPrefab = Resources.Load<GameObject>(ResourcesConst.ResourcesConst.SpawnPoints);
        
        spawnPointList.AddRange(SpawnPointsPrefab.GetComponentsInChildren<Transform>());
        spawnPointList.Remove(SpawnPointsPrefab.transform);
        
        _spawnPoints = spawnPointList.ToArray();

        _pool = new FallObjectPool(new FallObjectFactory());
        _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
        _typesCount = Enum.GetValues(typeof(FallObjectType)).Length;
    }

    public void StartSpawn()
    {
        TickableManager.UpdateNotify += Update;
    }
    public void StopSpawn()
    {
        TickableManager.UpdateNotify -= Update;
        Pool.AllReturnToPool();
    }
    
    private void Update()
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
