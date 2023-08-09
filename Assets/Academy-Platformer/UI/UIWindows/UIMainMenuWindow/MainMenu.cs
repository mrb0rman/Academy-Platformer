using UIService;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public UIMainMenuWindow mainMenuView;
    void Start()
    {
        var controller = new UIMainMenuWindowController(mainMenuView);
    }
}
