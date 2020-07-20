using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер камеры
/// </summary>
public class CameraController : MonoBehaviour
{
    private Camera mainCamera = null;

    public void Init()
    {
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Устанавливаем дистанцию видимости камеры
    /// </summary>
    /// <param name="volume"></param>
    public void SetCamDistance(float volume)
    {
        mainCamera.farClipPlane = volume;
    }
}