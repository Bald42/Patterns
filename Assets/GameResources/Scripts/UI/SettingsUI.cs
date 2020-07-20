using UnityEngine;
using UnityEngine.UI;
using Settings;

/// <summary>
/// Панель настроект
/// </summary>
public class SettingsUI : MonoBehaviour
{
    [SerializeField] private SettingsFacade settingsFacade = null;
    [Header("Настройки звука")]
    [SerializeField] private Slider soundSlider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Toggle muteToggle = null;
    [Header("Настройки графики")]
    [SerializeField] private Dropdown dropdownQuality = null;
    [SerializeField] private Slider camDistanceSlider = null;

    private void OnEnable()
    {
        SetVisualSettings();
        SubscribeButton();
    }

    private void OnDisable()
    {
        UnSubscribeButton();
    }

    private void SubscribeButton()
    {
        soundSlider.onValueChanged.AddListener(OnChangeSoundVolume);
        musicSlider.onValueChanged.AddListener(OnChangeMusicVolume);
        muteToggle.onValueChanged.AddListener(OnChangeMute);
        dropdownQuality.onValueChanged.AddListener(OnChangeQuality);
        camDistanceSlider.onValueChanged.AddListener(OnChangeCamDistance);
    }

    private void UnSubscribeButton()
    {
        soundSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
        muteToggle.onValueChanged.RemoveAllListeners();
        dropdownQuality.onValueChanged.RemoveAllListeners();
        camDistanceSlider.onValueChanged.RemoveAllListeners();
    }

    private void SetVisualSettings()
    {
        CheckActiveSliders();        
        muteToggle.isOn = SettingsParametrs.IsMute;
        dropdownQuality.value = SettingsParametrs.QualityValue;
        camDistanceSlider.value = SettingsParametrs.CamDistanceShift;
    }

    private void CheckActiveSliders()
    {
        soundSlider.interactable = !SettingsParametrs.IsMute;
        musicSlider.interactable = !SettingsParametrs.IsMute;

        soundSlider.value = SettingsParametrs.SoundVolume;
        musicSlider.value = SettingsParametrs.MusicVolume;
    }

    private void OnChangeSoundVolume (float volume)
    {
        settingsFacade.SetSoundVolume(volume);
    }

    private void OnChangeMusicVolume(float volume)
    {
        settingsFacade.SetMusicVolume(volume);
    }

    private void OnChangeMute(bool isMute)
    {
        settingsFacade.SetMute(isMute);
        CheckActiveSliders();
    }

    private void OnChangeQuality(int qualityValue)
    {
        settingsFacade.SetChangeQuality(qualityValue);
    }

    private void OnChangeCamDistance(float value)
    {
        settingsFacade.SetCamDistance(value);
    }

    /// <summary>
    /// Завершение перемещения слайдера
    /// </summary>
    //public void OnEndDrag()
    //{
    //    Debug.LogError($"OnEndDrag");
    //}
}