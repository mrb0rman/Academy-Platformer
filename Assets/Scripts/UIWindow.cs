using System;
using UnityEngine;
using DG.Tweening;

namespace DefaultNamespace
{
    public abstract class UIWindow : MonoBehaviour
    {
        private float duration = 1f;
        
        public void CloseAnimation()
        {
            transform.DOScale(Vector3.zero, duration);
        }

        public void OpenAnimation()
        {
            transform.DOScale(Vector3.one, duration);
        }
    }
}