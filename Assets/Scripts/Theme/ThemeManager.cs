using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager Instance { get; private set; }

    private const string ThemeKey = "SelectedTheme";

    [Header("Темы")]
    [SerializeField] private ThemeData[] themes;
    [Header("Текущая тема")]
    [SerializeField] private ThemeData currentTheme;

    public ThemeData CurrentTheme => currentTheme;

    private void Awake()
    {
        // Если ThemeManager уже существует, уничтожаем дубликат
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Делаем ThemeManager глобальным между сценами
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadTheme();
    }


    public void SetTheme(ThemeData theme)
    {
        if (theme == null)
        {
            Debug.LogWarning("ThemeManager: тема не задана.");
            return;
        }

        currentTheme = theme;

        SaveTheme();
    }

    private void SaveTheme()
    {
        PlayerPrefs.SetString(ThemeKey, currentTheme.ThemeName);
        PlayerPrefs.Save();
    }

    private void LoadTheme()
    {
        if (!PlayerPrefs.HasKey(ThemeKey))
        {
            currentTheme = themes[0];
            return;
        }

        string savedThemeName = PlayerPrefs.GetString(ThemeKey);

        foreach (ThemeData theme in themes)
        {
            if (theme.ThemeName == savedThemeName)
            {
                currentTheme = theme;
                return;
            }
        }

        currentTheme = themes[0];
    }
}
