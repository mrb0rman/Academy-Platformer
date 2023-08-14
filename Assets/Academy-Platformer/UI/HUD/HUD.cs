using UnityEngine;
using UnityEngine.UI;

namespace UIService
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private int currentScore = 0;
        [SerializeField] private Text text;
        [SerializeField] private Transform healthsBar;
        
        public int СurrentScore {
            get
            {
                return currentScore;
            }
            private set
            {
                currentScore = value;
                ChangeTextScore();
            }
        } 
        public float СurrentHealth
        {
            get
            {
                var healthsBarLocalScale = healthsBar.localScale;
                return healthsBarLocalScale.x;
            }
            private set
            {
                var healthsBarLocalScale = healthsBar.localScale;
                
                if (value > 1)
                {
                    healthsBarLocalScale.x = 1;
                }
                else if (value < 0)
                {
                    healthsBarLocalScale.x = 0;
                }
                else
                {
                    healthsBarLocalScale.x = value;
                }
            
                healthsBar.localScale = healthsBarLocalScale;
            } 
        }

        public void AddHealthPoint(float healthPoint)
        {
            СurrentHealth = СurrentHealth + healthPoint;
        }

        public void AddScore(int score)
        {
            СurrentScore += score;
            ChangeTextScore();
        }

        public void SetParametrs(int score, float healthPoint)
        {
            СurrentHealth = healthPoint;
            СurrentScore = score;
        }

        public void DefaultParametrs()
        {
            СurrentHealth = 1;
            СurrentScore = 0;
        }
    
        private void ChangeTextScore()
        {
            text.text = currentScore.ToString();
        }
    }
}


