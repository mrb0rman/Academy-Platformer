using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Color downColor;
    [SerializeField] private Sprite downImage;
    
    public void OnEnable()
    {
        button.onClick.AddListener(()=>OnClick());
        
    }
    public void OnClick()
    {
        if (button.transition == Selectable.Transition.ColorTint)
        {
            ChangeColor();
        }
        else if (button.transition == Selectable.Transition.SpriteSwap)
        {
            ChangeSprite();
        }
    }
    public void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
    
    private void ChangeColor()
    { 
        var buttonColors = button.colors;
        buttonColors.selectedColor = downColor;
        button.colors = buttonColors;
    }
    private void ChangeSprite()
    {
        var buttonSprite = button.spriteState;
        buttonSprite.selectedSprite = downImage;
        button.spriteState = buttonSprite;
    }
    
}
