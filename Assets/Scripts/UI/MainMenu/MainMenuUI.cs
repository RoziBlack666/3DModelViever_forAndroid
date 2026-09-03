using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelInfo;
    [SerializeField] private GameObject panelSettings;

    [Header("Text")]
    [SerializeField] private GameObject textHeading;

    [Header("Buttons")]
    [SerializeField] private GameObject butInfo;
    [SerializeField] private GameObject butSettings;
    [SerializeField] private GameObject butStart;

    [Header("ThemeUI")]
    [SerializeField] private ThemeUIElement imageInfo;
    [SerializeField] private ThemeUIElement imageSettings;

    [Header("ThemeController")]
    [SerializeField] private ThemeController themeController;


    public void ShowPanelInfo()
    {
        if (panelInfo != null)
        {
            panelInfo.SetActive(true);
            themeController.SetButtonEnabled(imageInfo);
        }
    }
    public void ShowPanelSettings()
    {
        if (panelSettings != null)
        {
            panelSettings.SetActive(true);
            themeController.SetButtonEnabled(imageInfo);
            themeController.SetButtonEnabled(imageSettings);
        }
    }


    public void HidePanelInfo()
    {
        if (panelInfo != null)
        {
            panelInfo.SetActive(false);
            themeController.SetButtonDisabled(imageInfo);
        }

    }
    public void HidePanelSettings()
    {
        if (panelSettings != null)
        {
            panelSettings.SetActive(false);
            themeController.SetButtonDisabled(imageInfo);
            themeController.SetButtonDisabled(imageSettings);
        }
    }

    public bool isActivePanelInfo()
    {
        return panelInfo.activeSelf;
    }
    public bool isActivePanelSettings()
    {
        return panelSettings.activeSelf;
    }

}
