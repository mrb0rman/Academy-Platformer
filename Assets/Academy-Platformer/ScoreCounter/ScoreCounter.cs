using Academy_Platformer.FallObject;
using UnityEngine;

namespace Academy_Platformer.ScoreCounter
{
    public class ScoreCounter : MonoBehaviour
    {
        public int Score => _score;
        
        [SerializeField] private int _score;

        public ScoreCounter(FallObjectController fallObjectController)
        {
            fallObjectController.PlayerCatchFallingObjectNotify += PlayerCatchFallObjectEventHandler;
        }

        public void PlayerCatchFallObjectEventHandler(FallObjectModel model)
        {
            _score += model.PointsPerObject;
        }
    }
}
