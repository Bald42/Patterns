using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пулл пуль
/// </summary>
public class PoolBullets : MonoBehaviour
{
    public static PoolBullets Instance = null;

    [SerializeField] private Bullet prefabBullet = null;
    [SerializeField] private Transform parentBullet = null;

    private List<Bullet> bullets = new List<Bullet>();

    private Bullet currentBullet = null;

    #region Initialization
    public void Init()
    {
        ApplyInstance(this);
    }

    private void ApplyInstance(PoolBullets instance)
    {
        Instance = instance;
    }

    private void OnDestroy()
    {
        ApplyInstance(null);
    }
    #endregion

    /// <summary>
    /// Получить свободную пулю
    /// </summary>
    public Bullet GetBullet
    {
        get
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].IsFree)
                {
                    currentBullet = bullets[i];
                    return currentBullet;
                }
            }
            SpawnBullet();
            return currentBullet;
        }
    }

    private void SpawnBullet()
    {
        currentBullet = Instantiate(prefabBullet, parentBullet);
        currentBullet.gameObject.name = currentBullet.gameObject.name.Replace("(Clone)", bullets.Count.ToString());
        bullets.Add(currentBullet);
    }
}