using System;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Camera MainCamera => mainCamera;
    
    [SerializeField] private  Camera mainCamera;
}