using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeUIElement : MonoBehaviour
{
    public enum ThemeColorType
    {
        Base,
        InactiveButton,
        ActiveButton,
        InactiveSmallButton,
        ActiveSmallButton,
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
    [SerializeField] private bool isActive;

    private Image image;
    private TMP_Text text;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponent<TMP_Text>();
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

            case ThemeColorType.InactiveButton:
                return theme.InactiveBut;

            case ThemeColorType.ActiveButton:
                return theme.ActiveBut;

            case ThemeColorType.InactiveSmallButton:
                return theme.InactiveBitBut;

            case ThemeColorType.ActiveSmallButton:
                return theme.ActiveBitBut;

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
        isActive = !isActive;

        ApplyButtonState(theme);
    }


    public void SetButtonState(bool active, ThemeData theme)
    {
        isActive = active;

        ApplyButtonState(theme);
    }


    private void ApplyButtonState(ThemeData theme)
    {
        if (theme == null)
            return;

        Color color;

        if (isActive)
        {
            if (colorType == ThemeColorType.InactiveSmallButton ||
                colorType == ThemeColorType.ActiveSmallButton)
            {
                color = theme.ActiveBitBut;
            }
            else
            {
                color = theme.ActiveBut;
            }
        }
        else
        {
            if (colorType == ThemeColorType.InactiveSmallButton ||
                colorType == ThemeColorType.ActiveSmallButton)
            {
                color = theme.InactiveBitBut;
            }
            else
            {
                color = theme.InactiveBut;
            }
        }

        if (image != null)
        {
            image.color = color;
        }
    }

    public bool IsActive => isActive;
}
