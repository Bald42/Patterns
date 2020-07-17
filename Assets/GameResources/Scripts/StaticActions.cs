using System;
using UnityEngine;

/// <summary>
/// Глобальные события
/// </summary>
public class StaticActions : MonoBehaviour
{
    public static Action<IBulletFactory, Vector3> OnShotEvent = null;
}