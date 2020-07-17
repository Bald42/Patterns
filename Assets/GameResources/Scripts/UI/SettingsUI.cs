using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Settings;

/// <summary>
/// Панель настроект
/// </summary>
public class SettingsUI : MonoBehaviour
{
    [SerializeField] private SettingsFacade settingsFacade = null;
    [SerializeField] private Slider soundSlider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Toggle muteToggle = null;

    private void OnEnable()
    {
        SetVisualSettings();
    }

    private void SetVisualSettings()
    {
        CheckActiveSliders();
        soundSlider.value = SettingsParametrs.SoundVolume;
        musicSlider.value = SettingsParametrs.MusicVolume;
        muteToggle.isOn = SettingsParametrs.IsMute;
    }

    private void CheckActiveSliders()
    {
        soundSlider.interactable = !SettingsParametrs.IsMute;
        musicSlider.interactable = !SettingsParametrs.IsMute;
    }
}