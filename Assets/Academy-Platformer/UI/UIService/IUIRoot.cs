using UnityEngine;

namespace UIService
{
    public interface IUIRoot
    {
        Transform Container { get; }
        Transform PoolContainer { get; }
    }
}