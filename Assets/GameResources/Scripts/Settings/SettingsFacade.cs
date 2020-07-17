using UnityEngine;
using Settings;

/// <summary>
/// Контроллер настроек (реализация фасада)
/// </summary>
public class SettingsFacade : MonoBehaviour
{    
    [SerializeField] private MusicController musicController = null;
    private Camera mainCamera = null;

    public void Init()
    {
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Устанавливаем громкость звуков
    /// </summary>
    /// <param name="volume"></param>
    public void SetSoundValue(float volume)
    {
        SettingsParametrs.SoundVolume = volume;
    }

    /// <summary>
    /// Устанавливаем громкость музыки
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicValue(float volume)
    {
        SettingsParametrs.MusicVolume = volume;
        musicController.SetMusicVolume();
    }

    /// <summary>
    /// Устанавливаем дистанцию видимости камеры
    /// </summary>
    /// <param name="volume"></param>
    public void SetCamDistance(float volume)
    {
        SettingsParametrs.CamDistanceCurrent = (SettingsParametrs.CamDistanceMax - SettingsParametrs.CamDistanceMin) *
                                                volume + SettingsParametrs.CamDistanceMin;
        mainCamera.farClipPlane = SettingsParametrs.CamDistanceCurrent;
    }

    /// <summary>
    /// Установить mute
    /// </summary>
    /// <param name="isMute"></param>
    public void SetMute (bool isMute)
    {
        SettingsParametrs.IsMute = isMute;
        float soundValue = 0f;
        float musicValue = 0f;
        if (isMute)
        {
            SettingsParametrs.SoundVolumeOld = SettingsParametrs.SoundVolume;
            SettingsParametrs.MusicVolumeOld = SettingsParametrs.MusicVolume;
        }
        else
        {
            soundValue = SettingsParametrs.SoundVolume = SettingsParametrs.SoundVolumeOld;
            musicValue = SettingsParametrs.MusicVolume = SettingsParametrs.MusicVolumeOld;
        }
        SetSoundValue(soundValue);
        SetMusicValue(musicValue);
    }
}