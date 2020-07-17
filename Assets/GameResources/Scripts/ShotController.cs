using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер выстрелов
/// </summary>
public class ShotController : MonoBehaviour
{
    [SerializeField] Transform startShotPoint = null;
    private IBulletFactory bulletFactory = null;
    public void Init()
    {
        Subscribe();
    }

    #region Subscribes / UnSubscribes
    /// <summary>Подписки</summary>
    private void Subscribe()
    {
        StaticActions.OnShotEvent += OnShot;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        StaticActions.OnShotEvent -= OnShot;
    }

    private void OnShot(IBulletFactory bulletFactory, Vector3 direction)
    {
        Bullet bullet = PoolBullets.Instance.GetBullet;
        bullet.SetParametrs(bulletFactory);
        bullet.FireBullet(startShotPoint.position, direction);
    }
    #endregion

    private void OnDestroy()
    {
        UnSubscribe();
    }
}