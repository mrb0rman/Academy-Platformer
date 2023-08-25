using System;
using Academy_Platformer.FallObject;
using Academy_Platformer.FallObject.Factory;
using Academy_Platformer.ScoreCounter;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallObjectSpawner
{
    public FallObjectPool Pool => _pool;
    
    private readonly ScoreCounter _scoreCounter;
    private readonly FallObjectPool _pool;
    private readonly float _spawnPeriodMin;
    private readonly float _spawnPeriodMax;
    private readonly float _minPositionX;
    private readonly float _maxPositionX;
    private readonly float _positionY;
    private Vector3 _spawnPosition;
    private float _spawnPeriod;
    private int _typesCount;

    public FallObjectSpawner(ScoreCounter scoreCounter)
    {
        var spawnerConfig = Resources.Load<FallObjectSpawnConfig>(ResourcesConst.ResourcesConst.FallObjectSpawnConfig);
        _positionY = spawnerConfig.PositionY;
        _minPositionX = spawnerConfig.MinPositionX;
        _maxPositionX = spawnerConfig.MaxPositionX;
        _spawnPeriodMin = spawnerConfig.SpawnPeriodMin;
        _spawnPeriodMax = spawnerConfig.SpawnPeriodMax;
        _spawnPosition = new Vector2(Random.Range(_minPositionX, _maxPositionX), _positionY);
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
        var newObjectController = _pool.GetController(newObject);
        _spawnPosition.x = Random.Range(_minPositionX, _maxPositionX);
        newObject.gameObject.transform.position = _spawnPosition;
        
        newObjectController.ObjectFellNotify += (FallObjectController) => _pool.ReturnToPool(newObject);
        newObjectController.PlayerCatchFallingObjectNotify += (FallObjectController) => _pool.ReturnToPool(newObject);
        newObjectController.ObjectFellNotify += _scoreCounter.ObjectFellEventHandler;
        newObjectController.PlayerCatchFallingObjectNotify += _scoreCounter.PlayerCatchFallObjectEventHandler;
    }
}
