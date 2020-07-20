using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обработчик ввода
/// </summary>
public class InputController : MonoBehaviour
{
    private bool isActive = false;
    private Camera camera = null;

    public void Init()
    {
        isActive = true;
        camera = Camera.main;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        OnClick();
    }

    private void OnClick()
    {
        if (Input.mousePosition.y > Screen.height * 0.9f)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MoveBullet(new ItemBulletSmall());
        }

        if (Input.GetMouseButtonDown(1))
        {
            MoveBullet(new ItemRocket());
        }

        if (Input.GetMouseButtonDown(2))
        {
            MoveBullet(new ItemBulletBig());
        }
    }

    public void SetActiveInput(bool activeChange)
    {
        isActive = activeChange;
    }

    private void MoveBullet(IBulletFactory bulletFactory)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        Vector3 direction = mousePos - camera.transform.position;
        StaticActions.OnShotEvent?.Invoke(bulletFactory, direction);
    }
}