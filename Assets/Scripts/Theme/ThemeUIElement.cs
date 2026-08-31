using UnityEngine;
using UnityEngine.UI;

public class ThemeUIElement : MonoBehaviour
{
    public enum ThemeColorType
    {
        Base,
        DisabledButton,
        EnabledButton,
        DisabledSmallButton,
        EnabledSmallButton,
        ImageInMenuBase,
        ImageInMenuForPanel,
        ImageInGallery,
        Text,
        Gallery,
        PanelThatOpens
    }

    [Header("Тип цвета")]
    [SerializeField] private ThemeColorType colorType;

    [Header("Состояние кнопки")]
    [SerializeField] private bool isEnabled;

    private Image image;
    private Text text;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponent<Text>();
    }


    public void ApplyTheme(ThemeData theme)
    {
        if (theme == null)
            return;

        Color color = GetThemeColor(theme);

        if (image != null)
        {
            image.color = color;
        }

        if (text != null)
        {
            text.color = color;
        }
    }


    private Color GetThemeColor(ThemeData theme)
    {
        switch (colorType)
        {
            case ThemeColorType.Base:
                return theme.Base;

            case ThemeColorType.DisabledButton:
                return theme.DisabledBut;

            case ThemeColorType.EnabledButton:
                return theme.EnabledBut;

            case ThemeColorType.DisabledSmallButton:
                return theme.DisabledBitBut;

            case ThemeColorType.EnabledSmallButton:
                return theme.EnabledBitBut;

            case ThemeColorType.ImageInMenuBase:
                return theme.ImageInMenuBase;

            case ThemeColorType.ImageInMenuForPanel:
                return theme.ImageInMenuForPanel;

            case ThemeColorType.ImageInGallery:
                return theme.ImageInGallery;

            case ThemeColorType.Text:
                return theme.Text;

            case ThemeColorType.Gallery:
                return theme.Gallery;

            case ThemeColorType.PanelThatOpens:
                return theme.PanelThatOpens;

            default:
                return Color.white;
        }
    }


    public void ToggleButtonState(ThemeData theme)
    {
        isEnabled = !isEnabled;

        ApplyButtonState(theme);
    }


    public void SetButtonState(bool enabled, ThemeData theme)
    {
        isEnabled = enabled;
        ApplyButtonState(theme);
    }


    private void ApplyButtonState(ThemeData theme)
    {
        if (theme == null)
            return;

        Color color;

        if (isEnabled)
        {
            if (colorType == ThemeColorType.DisabledSmallButton ||
                colorType == ThemeColorType.EnabledSmallButton)
            {
                color = theme.EnabledBitBut;
            }
            else
            {
                color = theme.EnabledBut;
            }
        }
        else
        {
            if (colorType == ThemeColorType.DisabledSmallButton ||
                colorType == ThemeColorType.EnabledSmallButton)
            {
                color = theme.DisabledBitBut;
            }
            else
            {
                color = theme.DisabledBut;
            }
        }

        if (image != null)
        {
            image.color = color;
        }
    }

    public bool IsEnabled => isEnabled;


    private void OnEnable()
    {
        if (ThemeManager.Instance != null)
        {
            ApplyTheme(ThemeManager.Instance.CurrentTheme);
        }
    }
}
