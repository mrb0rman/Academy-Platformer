using Academy_Platformer.FallObject;
using UnityEngine;

namespace Academy_Platformer.ScoreCounter
{
    public class ScoreCounter
    {
        public int Score => _score;
        
        private int _score;

        public void PlayerCatchFallObjectEventHandler(FallObjectController controller)
        {
            _score += controller.PointsPerObject;
        }        
        public void ObjectFellEventHandler(FallObjectController controller)
        {
            _score -= controller.Damage;
        }
    }
}
