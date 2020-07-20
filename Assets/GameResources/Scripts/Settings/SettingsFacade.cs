using UnityEngine;
using Settings;

/// <summary>
/// Контроллер настроек (реализация фасада)
/// </summary>
public class SettingsFacade : MonoBehaviour
{    
    private MusicController musicController = null;
    private CameraController cameraController = null;

    public void Init(MusicController _musicController,
                     CameraController _cameraController)
    {
        cameraController = _cameraController;
        musicController = _musicController;
    }

    /// <summary>
    /// Устанавливаем громкость звуков
    /// </summary>
    /// <param name="volume"></param>
    public void SetSoundVolume(float volume)
    {
        SettingsParametrs.SetSoundVolume(volume);
    }

    /// <summary>
    /// Устанавливаем громкость музыки
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume)
    {
        SettingsParametrs.SetMusicVolume(volume);
        musicController.SetMusicVolume();
    }

    /// <summary>
    /// Устанавливаем дистанцию видимости камеры
    /// </summary>
    /// <param name="volume"></param>
    public void SetCamDistance(float value)
    {
        SettingsParametrs.SetCamDistance(value);
        cameraController.SetCamDistance(SettingsParametrs.CamDistanceCurrent);
    }

    /// <summary>
    /// Установить mute
    /// </summary>
    /// <param name="isMute"></param>
    public void SetMute (bool isMute)
    {
        SettingsParametrs.SetMute(isMute);
        SetSoundVolume(SettingsParametrs.SoundVolume);
        SetMusicVolume(SettingsParametrs.MusicVolume);
    }

    /// <summary>
    /// Устанавливаем качество графики
    /// </summary>
    /// <param name="qualityValue"></param>
    public void SetChangeQuality(int qualityValue)
    {
        SettingsParametrs.QualityValue = qualityValue;
        QualitySettings.SetQualityLevel(SettingsParametrs.QualityValue, true);
    }    
}