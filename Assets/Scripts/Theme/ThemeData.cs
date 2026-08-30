using UnityEngine;

[CreateAssetMenu(
     fileName = "NewTheme" 
    ,menuName = "3DModelViewer/Theme"
)]
public class ThemeData : ScriptableObject
{
    public string ThemeName;

    [Header("Основные цвета")]
    public Color Base;

    [Header("Кнопки")]
    public Color InactiveBut;
    public Color ActiveBut;

    [Header("Маленькие кнопки")]
    public Color InactiveBitBut;
    public Color ActiveBitBut;

    [Header("Узоры")]
    public Color ImageInMenuBase;
    public Color ImageInMenuForPanel;
    public Color ImageInGallery;

    [Header("Текст")]
    public Color Text;

    [Header("Галерея")]
    public Color Gallery;

    [Header("Панели")]
    public Color PanelThatOpens;
}
