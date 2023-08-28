using System;
using FallObject;

public class ScoreCounter
{
    public event Action<int> ScoreChangeNotify;
    public int Score => _score;
        
    private int _score = 1;

    public void PlayerCatchFallObjectEventHandler(FallObjectController controller)
    {
        _score += controller.PointsPerObject;
        ScoreChangeNotify?.Invoke(controller.PointsPerObject);
    }        
    public void ObjectFellEventHandler(FallObjectController controller)
    {
        _score -= controller.Damage;
        ScoreChangeNotify?.Invoke(controller.Damage);
    }
}