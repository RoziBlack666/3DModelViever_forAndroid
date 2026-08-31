using UnityEngine;

public class ThemeController : MonoBehaviour
{
    [Header("UI элементы")]
    [SerializeField] private ThemeUIElement[] elements;

    private ThemeData CurrentTheme
    {
        get
        {
            if (ThemeManager.Instance == null)
            {
                Debug.LogWarning("ThemeController: ThemeManager не найден.");
                return null;
            }

            return ThemeManager.Instance.CurrentTheme;
        }
    }

    private void Start()
    {
        if (ThemeManager.Instance == null)
        {
            Debug.LogWarning("ThemeController: ThemeManager не найден.");
            return;
        }

        ThemeManager.Instance.OnThemeChanged += ApplyTheme;

        ApplyTheme();
    }

    private void OnDestroy()
    {
        if (ThemeManager.Instance != null)
        {
            ThemeManager.Instance.OnThemeChanged -= ApplyTheme;
        }
    }


    public void ApplyTheme()
    {
        ApplyTheme(CurrentTheme);
    }

    public void ApplyTheme(ThemeData theme)
    {
        if (theme == null)
        {
            Debug.LogWarning("ThemeController: тема не задана.");
            return;
        }

        foreach (ThemeUIElement element in elements)
        {
            if (element == null)
                continue;

            element.ApplyTheme(theme);
        }
    }


    public void ToggleButton(ThemeUIElement button)
    {
        if (button == null)
            return;

        button.ToggleButtonState(CurrentTheme);
    }


    public void SetButtonEnabled(ThemeUIElement button)
    {
        if (button == null)
            return;

        button.SetButtonState(true, CurrentTheme);        
    }
    public void SetButtonDisabled(ThemeUIElement button)
    {
        if (button == null)
            return;

        button.SetButtonState(false, CurrentTheme);
    }
}
