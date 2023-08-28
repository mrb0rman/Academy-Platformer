using System;
using FallObject;
using UnityEngine;

public class ScoreCounter
{
    public event Action<int> ScoreChangeNotify;
    public int Score { get => _score; }
        
    private int _score = 0;

    public void PlayerCatchFallObjectEventHandler(FallObjectController controller)
    {
        _score += controller.PointsPerObject;
        ScoreChangeNotify?.Invoke(_score);
    }
}