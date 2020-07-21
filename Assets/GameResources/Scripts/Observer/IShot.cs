using UnityEngine;

public interface IShot
{
    void OnShot(IBulletFactory bullet, Vector3 direction);
}