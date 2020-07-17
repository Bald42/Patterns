using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Обработка звуков выстрелов
/// </summary>
public class SoundShots : MonoBehaviour
{
    [SerializeField] List<ItemsSounds> itemsSounds = new List<ItemsSounds>();

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
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

    private void OnShot(IBulletFactory bulletFactory, Vector3 empty)
    {
        PlaySoundShot(bulletFactory);
    }
    #endregion

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

    [Serializable]
    private class ItemsSounds
    {
        public Enums.TypeBullet TypeBullet = Enums.TypeBullet.Null;
        public List<AudioClip> Clips = new List<AudioClip>();
    }
}