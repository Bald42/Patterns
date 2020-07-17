using UnityEngine;
using Settings;

/// <summary>
/// Контроллер музыки
/// </summary>
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;

    public void Init()
    {
        SetMusicVolume();
        audioSource.Play();
        audioSource.loop = true;        
    }

    /// <summary>
    /// Установить громкость музыки
    /// </summary>
    public void SetMusicVolume()
    {
        audioSource.volume = SettingsParametrs.MusicVolume;
    }
}