using UnityEngine;

/// <summary>
/// Порядок инициализации игровых элементов на сцене
/// </summary>
public class InitializeScene : MonoBehaviour
{
    [SerializeField] private PoolBullets poolBullets = null;
    [SerializeField] private InputController inputController = null;
    [SerializeField] private ShotController shotController = null;
    [SerializeField] private SoundController soundController = null;
    [SerializeField] private MusicController musicController = null;
    [SerializeField] private SettingsFacade settingsFacade = null;
    [SerializeField] private CameraController cameraController = null;

    private void Awake()
    {
        InitAll();
    }

    private void InitAll()
    {
        poolBullets.Init();
        inputController.Init();
        shotController.Init();
        soundController.Init();
        musicController.Init();
        cameraController.Init();
        settingsFacade.Init(musicController, cameraController);
    }
}