using UnityEngine;

namespace Academy_Platformer.UI.UIService
{
    public interface IUIRoot
    {
        Transform Container { get; }
        Transform PoolContainer { get; }
    }
}