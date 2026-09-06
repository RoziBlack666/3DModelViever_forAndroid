using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryPreviewController : MonoBehaviour
{
    [Header("Gallery")]
    [SerializeField] private ScrollRect scrollRect;

    [SerializeField] private RectTransform galleryContent;

    [Header("Preview")]
    [SerializeField] private RectTransform previewArea;

    private List<RectTransform> items =
        new List<RectTransform>();

    private int currentIndex = -1;

    public bool IsOpened { get; private set; }

    private void Awake()
    {
        FindItems();
    }

    private void FindItems()
    {
        items.Clear();

        for (int i = 0; i < galleryContent.childCount; i++)
        {
            RectTransform item =
                galleryContent.GetChild(i)
                as RectTransform;

            if (item != null)
            {
                items.Add(item);
            }
        }
    }

    public void Open(int index)
    {
        if (index < 0 || index >= items.Count)
            return;

        currentIndex = index;
        IsOpened = true;

        // Отключаем обычный ScrollRect
        if (scrollRect != null)
        {
            scrollRect.enabled = false;
        }

        ShowCurrent();
    }

    public void ShowNext()
    {
        if (!IsOpened)
            return;

        if (currentIndex >= items.Count - 1)
            return;

        currentIndex++;

        ShowCurrent();
    }

    public void ShowPrevious()
    {
        if (!IsOpened)
            return;

        if (currentIndex <= 0)
            return;

        currentIndex--;

        ShowCurrent();
    }

    private void ShowCurrent()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(
                i == currentIndex
            );
        }

        RectTransform currentItem =
            items[currentIndex];

        currentItem.SetParent(
            previewArea,
            false
        );

        currentItem.anchorMin = Vector2.zero;
        currentItem.anchorMax = Vector2.one;

        currentItem.offsetMin = Vector2.zero;
        currentItem.offsetMax = Vector2.zero;
    }

    public void Close()
    {
        IsOpened = false;

        if (scrollRect != null)
        {
            scrollRect.enabled = true;
        }

        // Пока возвращаем элементы обратно
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(true);
        }
    }
}
