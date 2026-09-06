using UnityEngine;
using UnityEngine.UI;

public class GalleryGridController : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private GridLayoutGroup grid;

    [Header("Settings")]
    [SerializeField] private float sidePadding = 50f;
    [SerializeField] private float spacing = 50f;

    [SerializeField] private float minItemWidth = 300f;
    [SerializeField] private int maxColumns = 3;

    [Header("Item Proportions")]
    [SerializeField] private float itemHeightMultiplier = 1.8f;

    private void Start()
    {
        UpdateGrid();
    }

    private void OnRectTransformDimensionsChange()
    {
        UpdateGrid();
    }

    private void UpdateGrid()
    {
        if (grid == null)
            return;

        RectTransform rect = grid.GetComponent<RectTransform>();

        float availableWidth = rect.rect.width;

        if (availableWidth <= 0)
            return;

        // Вычисляем количество колонок
        int columns = Mathf.Max(
            1,
            Mathf.FloorToInt(
                (availableWidth - sidePadding * 2f + spacing) /
                (minItemWidth + spacing)
            )
        );

        // Ограничиваем количество колонок
        columns = Mathf.Min(columns, maxColumns);

        // Вычисляем ширину карточки
        float itemWidth =
            (availableWidth
            - sidePadding * 2f
            - spacing * (columns - 1))
            / columns;

        // Настраиваем Grid
        grid.padding.left = Mathf.RoundToInt(sidePadding);
        grid.padding.right = Mathf.RoundToInt(sidePadding);

        grid.spacing = new Vector2(spacing, spacing);

        grid.constraint =
            GridLayoutGroup.Constraint.FixedColumnCount;

        grid.constraintCount = columns;

        grid.cellSize = new Vector2(
            itemWidth,
            itemWidth * itemHeightMultiplier
        );
    }
}
