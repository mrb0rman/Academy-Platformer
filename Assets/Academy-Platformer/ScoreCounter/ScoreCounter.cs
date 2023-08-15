using Academy_Platformer.FallObject;
using UnityEngine;

namespace Academy_Platformer.ScoreCounter
{
    public class ScoreCounter
    {
        public int Score => _score;
        
        private int _score;

        public ScoreCounter(FallObjectController fallObjectController)
        {
            fallObjectController.PlayerCatchFallingObjectNotify += PlayerCatchFallObjectEventHandler;
            fallObjectController.ObjectFellNotify += ObjectFellEventHandler;
        }

        public void PlayerCatchFallObjectEventHandler(FallObjectModel model)
        {
            _score += model.PointsPerObject;
        }        
        public void ObjectFellEventHandler(FallObjectModel model)
        {
            _score -= model.Damage;
        }
    }
}
