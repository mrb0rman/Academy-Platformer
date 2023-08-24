using System;
using Academy_Platformer.FallObject;
using Academy_Platformer.FallObject.Factory;
using Academy_Platformer.ScoreCounter;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallObjectSpawner
{
    public FallObjectPool Pool => _pool;

    private float _minPositionX;
    private float _maxPositionX;
    private float _positionY;
    private readonly ScoreCounter _scoreCounter;
    private FallObjectPool _pool;

    private float _spawnPeriodMin;
    private float _spawnPeriodMax;
    private float _spawnPeriod;
    private int _typesCount;

    public FallObjectSpawner(float minPositionX,
        float maxPositionX,
        float spawnPeriodMin,
        float spawnPeriodMax, 
        float positionY,
        ScoreCounter scoreCounter)
    {
        _positionY = positionY;
        _minPositionX = minPositionX;
        _maxPositionX = maxPositionX;
        _spawnPeriodMin = spawnPeriodMin;
        _spawnPeriodMax = spawnPeriodMax;
        _scoreCounter = scoreCounter;

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
            SpawnNewObject();
            _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
        }
    }

    private void SpawnNewObject()
    {
        var type = Random.Range(0, _typesCount);
        var newObject = _pool.CreateObject((FallObjectType)type);
        newObject.gameObject.transform.position = new Vector3(Random.Range(_minPositionX, _maxPositionX), _positionY, 0);
        var newObjectController = _pool.GetController(newObject);
        newObjectController.ObjectFellNotify += (FallObjectController) => _pool.ReturnToPool(newObject);
        newObjectController.PlayerCatchFallingObjectNotify += (FallObjectController) => _pool.ReturnToPool(newObject);
        newObjectController.ObjectFellNotify += _scoreCounter.ObjectFellEventHandler;
        newObjectController.PlayerCatchFallingObjectNotify += _scoreCounter.PlayerCatchFallObjectEventHandler;
    }
}
