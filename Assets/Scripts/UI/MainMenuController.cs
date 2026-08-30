using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private MainMenuUI mainMenuUI;
    [Header("Scene")]
    [SerializeField] private SceneController sceneController;


    private void Start()
    {
        Initialize();
    }

    /// Начальная настройка главного меню.
    private void Initialize()
    {
        if (mainMenuUI == null)
        {
            Debug.LogError("MainMenuController: MainMenuUI не назначен.");
            return;
        }

        CloseInfo();
        CloseSettings();
    }


    public void OnClickButInfo()
    {
        ChangeActivePanelInfo();
    }
    public void OnClickButSettings()
    {
        ChangeActivePanelSettings();
    }
    public void OnClickButStart()
    {
        OpenGallery();
    }


    public void ChangeActivePanelInfo()
    {
        if (mainMenuUI.isActivePanelInfo())
        {
            CloseInfo();
        }
        else 
        {
            CloseSettings();
            OpenInfo();
        }
    }
    public void ChangeActivePanelSettings()
    {
        if(mainMenuUI.isActivePanelSettings()) 
        { 
            CloseSettings();
        }
        else
        {
            CloseInfo();
            OpenSettings();
        }

    }


    public void OpenInfo()
    {
        if (mainMenuUI == null)
            return;

        mainMenuUI.ShowPanelInfo();
    }
    public void OpenSettings()
    {
        if (mainMenuUI == null)
            return;

        mainMenuUI.ShowPanelSettings();
    }


    public void CloseInfo()
    {
        if (mainMenuUI == null)
            return;

        mainMenuUI.HidePanelInfo();
    }
    public void CloseSettings()
    {
        if (mainMenuUI == null)
            return;

        mainMenuUI.HidePanelSettings();
    }


    public void OpenGallery()
    {
        if (sceneController == null)
        {
            Debug.LogError("MainMenuController: SceneController не назначен.");
            return;
        }

        sceneController.OpenGallery();
    }

}
