using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotObserver : MonoBehaviour
{
    [SerializeField] private List<IShot> endObservers = new List<IShot>();

    private InputController inputController = null;

    public void Init(InputController _inputController)
    {
        inputController = _inputController;
        inputController.OnShotEvent += OnShot;
    }

    private void OnDestroy()
    {
        inputController.OnShotEvent -= OnShot;
    }

    public void AddObserver(IShot observer)
    {
        endObservers.Add(observer);
    }

    public void RemoveObserver(IShot observer)
    {
        endObservers.Remove(observer);
    }

    private void OnShot(IBulletFactory bullet, Vector3 direction)
    {
        foreach(IShot observer in endObservers)
        {
            observer.OnShot(bullet, direction);
        }
    }
}
