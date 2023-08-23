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

    private const float SpawnPeriodMin = 1f;
    private const float SpawnPeriodMax = 4f;
    private float _spawnPeriod;
    private int _typesCount;

    public FallObjectSpawner()
    {
        var spawnPointList = new List<Transform>();
        var spawnPointsPrefab = Resources.Load<GameObject>(ResourcesConst.ResourcesConst.SpawnPoints);
        
        spawnPointList.AddRange(spawnPointsPrefab.GetComponentsInChildren<Transform>());
        spawnPointList.Remove(spawnPointsPrefab.transform);
        
        _spawnPoints = spawnPointList.ToArray();

        _pool = new FallObjectPool(new FallObjectFactory());
        _spawnPeriod = Random.Range(SpawnPeriodMin, SpawnPeriodMax);
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
            _spawnPeriod = Random.Range(SpawnPeriodMin, SpawnPeriodMax);
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
