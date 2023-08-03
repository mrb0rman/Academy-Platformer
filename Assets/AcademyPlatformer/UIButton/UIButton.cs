using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIButton
{
    public class UIButton : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] private Button button;

        [SerializeField] private bool UseColor = true;
        [SerializeField] private Color downColor;
        
        [SerializeField] private bool UseSprite;
        [SerializeField] private Sprite downImage;

        public delegate void OnClickEventHandler();
        public event OnClickEventHandler OnClickButton;

        private void OnEnable()
        {
            OnClickButton += OnClick;
        }

        private void OnDisable()
        {
            OnClickButton -= OnClick;
        }
        
        private void OnClick()
        {
            if (UseColor) ChangeColor();
            if (UseSprite) ChangeSprite();
        }
        
        private void ChangeColor()
        {
            button.transition = Selectable.Transition.ColorTint;
            var buttonColors = button.colors;
            buttonColors.selectedColor = downColor;
            button.colors = buttonColors;
        }

        private void ChangeSprite()
        {
            button.transition = Selectable.Transition.SpriteSwap;
            var buttonSprite = button.spriteState;
            buttonSprite.selectedSprite = downImage;
            button.spriteState = buttonSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickButton?.Invoke();
        }
    }
}