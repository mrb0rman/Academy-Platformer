using System;
using System.Collections;
using System.Collections.Generic;
using Academy_Platformer.FallObject;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallObjectSpawner
{
    private Transform[] _spawnPoints;

    private float _spawnPeriodMin;
    
    private float _spawnPeriodMax;

    private int _typesCount;

    private float _spawnPeriod;

    private FallObjectPool _pool;
    // Start is called before the first frame update
    public FallObjectSpawner(Transform[] spawnPoints, float spawnPeriodMin, float spawnPeriodMax)
    {
        _spawnPoints = spawnPoints;
        _spawnPeriodMin = spawnPeriodMin;
        _spawnPeriodMax = spawnPeriodMax;
        
        _pool = new FallObjectPool(new FallObjectController());
        _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
        _typesCount = Enum.GetValues(typeof(FallObjectType)).Length;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnPeriod -= Time.deltaTime;

        if (_spawnPeriod <= 0)
        {
            SpawnNewObject(Random.Range(0, 3));
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
