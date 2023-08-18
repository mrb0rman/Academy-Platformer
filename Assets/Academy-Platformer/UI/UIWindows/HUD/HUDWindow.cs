using UnityEngine;
using UnityEngine.UI;

namespace UIService
{
    public class HUDWindow : UIAnimationWindow
    {
        public int СurrentScore => currentScore;
        
        [SerializeField] private int currentScore = 0;
        [SerializeField] private Text text;
        [SerializeField] private Transform healthsBar;
        
        public float СurrentHealth
        {
            get
            {
                var healthsBarLocalScale = healthsBar.localScale;
                return healthsBarLocalScale.x;
            }
        }

        public void ChangeHealthBar(float healthPoint)
        {
            var healthsBarLocalScale = healthsBar.localScale;
            healthsBarLocalScale.x = healthPoint;
            healthsBar.localScale = healthsBarLocalScale;
        }

        public void ChangeScoreText(int score)
        {
            currentScore += score;
            text.text = currentScore.ToString();
        }
    }
}