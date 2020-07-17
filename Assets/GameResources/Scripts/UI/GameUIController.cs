using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Игровой ЮИ контроллер
/// </summary>
public class GameUIController : MonoBehaviour
{
    //TEMP
    [SerializeField] private GameObject settingsPanel = null;
    [SerializeField] private InputController inputController = null;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        settingsPanel.SetActive(false);
    }

    /// <summary>
    /// Включить/выключить панель настроек
    /// </summary>
    public void OnActiveSettingsPanel(bool isActive)
    {
        settingsPanel.SetActive(isActive);
        inputController.SetActiveInput(!isActive);
    }
}