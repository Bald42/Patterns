using UnityEngine;
using Settings;

/// <summary>
/// Контроллер воспроизведения звуков
/// </summary>
public class SoundController : MonoBehaviour
{
    public static SoundController Instance = null;

    [SerializeField] private AudioSource audioSource = null;

    public void Init()
    {
        ApplyInstance(this);
    }
    private void ApplyInstance(SoundController instance)
    {
        Instance = instance;
    }
    private void OnDestroy()
    {
        ApplyInstance(null);
    }

    /// <summary>
    /// Воспроизведение конкретного звука
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="valueValume"></param>
    public void Play(AudioClip audioClip, float valueValume = 1f)
    {
        audioSource.volume = SettingsParametrs.SoundVolume * valueValume;
        audioSource.PlayOneShot(audioClip);
    }
}