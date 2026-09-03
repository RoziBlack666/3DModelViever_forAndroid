using UnityEngine;
using UnityEngine.UI;

public class GalleryGridController : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;

    [SerializeField] private float sidePadding = 40f;
    [SerializeField] private float spacing = 40f;

    [SerializeField] private float minItemWidth = 450f;

    private void UpdateGrid()
    {
        RectTransform rect = grid.GetComponent<RectTransform>();

        float width = rect.rect.width;

        int columns = Mathf.Max(
            1,
            Mathf.FloorToInt(
                (width - sidePadding * 2 + spacing) /
                (minItemWidth + spacing)
            )
        );

        float itemWidth =
            (width - sidePadding * 2 - spacing * (columns - 1))
            / columns;

        grid.padding.left = Mathf.RoundToInt(sidePadding);
        grid.padding.right = Mathf.RoundToInt(sidePadding);

        grid.spacing = new Vector2(spacing, spacing);

        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = columns;

        grid.cellSize = new Vector2(
            itemWidth,
            itemWidth * 1.8f
        );
    }
}
