namespace UIService
{
    public class HUDWindowController
    {
        private readonly UIService _uiService;
        
        private HUDWindow _hudWindowWindow;

        public HUDWindowController(UIService uiService)
        {
            _uiService = uiService;
            _hudWindowWindow = uiService.Get<HUDWindow>();
            
            SetParameters();
        }
        
        public void ChangeHealthPoint(float healthPoint)
        {
            healthPoint = ChekHPPoint(healthPoint, _hudWindowWindow.СurrentHealth);
            _hudWindowWindow.ChangeHealthBar(healthPoint);
        }
        
        public void ChangeScore(int score)
        {
            _hudWindowWindow.ChangeScoreText(score);
        }
        
        public void SetParameters(int score = 0, float healthPoint = 1f)
        {
            ChangeScore(score);
            
            healthPoint = ChekHPPoint(healthPoint);
            _hudWindowWindow.ChangeHealthBar(healthPoint);
        }

        private float ChekHPPoint(float healthPoint, float currentHP = 0)
        {
            if (healthPoint + currentHP > 1)
            {
                currentHP = 1;
            }
            else if (healthPoint + currentHP < 0)
            {
                currentHP = 0;
            }
            else
            {
                currentHP += healthPoint;
            }
            return currentHP;
        }
    }
}