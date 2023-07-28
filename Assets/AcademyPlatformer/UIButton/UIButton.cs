using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Color downColor;
    [SerializeField] private Sprite downImage;
    void OnEnable()
    {
        if (_button.transition == Selectable.Transition.ColorTint)
        {
            _button.onClick.AddListener(() => ChangeColor(downColor));
        }
        else if (_button.transition == Selectable.Transition.SpriteSwap)
        {
            _button.onClick.AddListener(() => ChangeSprite(downImage));
        }
    }
    private void ChangeColor(Color colorDown)
    { 
        var buttonColors = _button.colors;
        buttonColors.selectedColor = colorDown;
        _button.colors = buttonColors;
    }
    private void ChangeSprite(Sprite spriteDown)
    {
        var buttonSprite = _button.spriteState;
        buttonSprite.selectedSprite = spriteDown;
        _button.spriteState = buttonSprite;
    }
}
