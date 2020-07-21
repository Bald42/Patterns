using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Обработка звуков выстрелов
/// </summary>
public class SoundShots : MonoBehaviour, IShot
{
    [SerializeField] List<ItemsSounds> itemsSounds = new List<ItemsSounds>();
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

    private void PlaySoundShot(IBulletFactory bulletFactory)
    {
        for (int i=0; i < itemsSounds.Count;i++)
        {
            if (itemsSounds[i].TypeBullet == bulletFactory.GetType())
            {
                int rndSound = UnityEngine.Random.Range(0, itemsSounds[i].Clips.Count);
                AudioClip clipShot = itemsSounds[i].Clips[rndSound];
                SoundController.Instance.Play(clipShot);
                break;
            }
        }
    }

    void IShot.OnShot(IBulletFactory bullet, Vector3 direction)
    {
        PlaySoundShot(bullet);
    }

    [Serializable]
    private class ItemsSounds
    {
        public Enums.TypeBullet TypeBullet = Enums.TypeBullet.Null;
        public List<AudioClip> Clips = new List<AudioClip>();
    }
}