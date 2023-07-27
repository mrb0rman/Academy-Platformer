using System;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    public Camera MainCamera => _mainCamera;

}
