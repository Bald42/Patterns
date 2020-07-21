using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер выстрелов
/// </summary>
public class ShotController : MonoBehaviour, IShot
{
    [SerializeField] Transform startShotPoint = null;
    private ShotObserver shotObserver = null;

    public void Init(ShotObserver _shotObserver)
    {
        shotObserver = _shotObserver;
        shotObserver.AddObserver(this);
    }

    private void OnDestroy()
    {
        shotObserver.RemoveObserver(this);
    }

    void IShot.OnShot(IBulletFactory bulletFactory, Vector3 direction)
    {
        Bullet bullet = PoolBullets.Instance.GetBullet;
        bullet.SetParametrs(bulletFactory);
        bullet.FireBullet(startShotPoint.position, direction);
    }
}