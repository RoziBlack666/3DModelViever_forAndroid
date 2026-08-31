using UnityEngine;
using UnityEngine.UI;

public class ThemeToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private ThemeData theme;

    private void Awake()
    {
        if (toggle == null)
        {
            toggle = GetComponent<Toggle>();
        }
    }

    private void Start()
    {
        LoadState();
    }

    public void OnToggleChanged(bool isOn)
    {
        if (!isOn)
            return;

        if (ThemeManager.Instance == null)
            return;

        ThemeManager.Instance.SetTheme(theme);
    }

    private void LoadState()
    {
        if (ThemeManager.Instance == null)
            return;

        if (ThemeManager.Instance.CurrentTheme == theme)
        {
            toggle.SetIsOnWithoutNotify(true);
        }
        else
        {
            toggle.SetIsOnWithoutNotify(false);
        }
    }
}
