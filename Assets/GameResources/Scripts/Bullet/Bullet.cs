using UnityEngine;
using System.Collections;

/// <summary>
/// Класс отвечающий за поведение пули
/// </summary>
public class Bullet : MonoBehaviour
{
    private bool isFree = true;
    private Rigidbody rigidbody = null;
    private float speed = 0f;
    private float lifeTime = 0f;
    private float scale = 0f;

    private IBulletFactory currentBulletFactory = null;
    private Coroutine coroutineDelayLifeBullet = null;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsFree
    {
        get
        {
            return isFree;
        }
    }

    public void SetParametrs(IBulletFactory bulletFactory)
    {
        if (currentBulletFactory != bulletFactory)
        {
            currentBulletFactory = bulletFactory;
            rigidbody.useGravity = bulletFactory.GetGravity();
            speed = bulletFactory.GetSpeed().Value();
            lifeTime = bulletFactory.GetLifeTime().Value();
            scale = bulletFactory.GetScale().Value();
            transform.localScale = Vector3.one * scale;
        }
    }

    public void FireBullet(Vector3 startPosition, Vector3 direction)
    {
        transform.position = startPosition;
        ActiveBullet(true);
        coroutineDelayLifeBullet = StartCoroutine(DelayLifeBullet());
        MoveBullet(direction);
    }

    private IEnumerator DelayLifeBullet()
    {
        if (coroutineDelayLifeBullet != null && lifeTime < 0)
        {
            StopCoroutine(coroutineDelayLifeBullet);
        }
        while (!isFree && lifeTime > 0)
        {
            yield return new WaitForSeconds(lifeTime);
            ActiveBullet(false);
        }
    }

    private void ActiveBullet(bool isActive)
    {
        if (!isActive)
        {
            rigidbody.velocity = Vector3.zero;
        }

        isFree = !isActive;
        gameObject.SetActive(isActive);
    }

    private void MoveBullet(Vector3 direction)
    {
        rigidbody.AddForce(direction * speed);
    }
}