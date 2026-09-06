using UnityEngine;
using UnityEngine.EventSystems;

public class GallerySwipeController : MonoBehaviour,
    IBeginDragHandler,
    IEndDragHandler
{
    [Header("Swipe")]
    [SerializeField] private float swipeThreshold = 100f;

    private Vector2 startPosition;

    private GalleryPreviewController previewController;

    public void Initialize(GalleryPreviewController controller)
    {
        previewController = controller;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (previewController == null)
            return;

        if (!previewController.IsOpened)
            return;

        startPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (previewController == null)
            return;

        if (!previewController.IsOpened)
            return;

        Vector2 delta = eventData.position - startPosition;

        if (Mathf.Abs(delta.x) < swipeThreshold)
            return;

        // Свайп влево → следующая модель
        if (delta.x < 0)
        {
            previewController.ShowNext();
        }
        // Свайп вправо → предыдущая модель
        else
        {
            previewController.ShowPrevious();
        }
    }
}
