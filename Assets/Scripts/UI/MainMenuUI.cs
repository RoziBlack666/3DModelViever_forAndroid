using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelInfo;
    [SerializeField] private GameObject panelSettings;

    [Header("Buttons")]
    [SerializeField] private GameObject butInfo;
    [SerializeField] private GameObject butSettings;
    [SerializeField] private GameObject butStart;

    [Header("Text")]
    [SerializeField] private GameObject textHeading;

    public void ShowPanelInfo()
    {
        if (panelInfo != null)
            panelInfo.SetActive(true);
    }
    public void ShowPanelSettings()
    {
        if (panelSettings != null)
            panelSettings.SetActive(true);
    }


    public void HidePanelInfo()
    {
        if (panelInfo != null)
            panelInfo.SetActive(false);
    }
    public void HidePanelSettings()
    {
        if (panelSettings != null)
            panelSettings.SetActive(false);
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
