using UnityEngine;

public class GalleryController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GalleryUI galleryUI;
    [Header("Scene")]
    [SerializeField] private SceneController sceneController;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (galleryUI == null)
        {
            Debug.LogError("MainMenuController: GalleryUI не назначен.");
            return;
        }

        galleryUI.setEnabledButPlay(false);
        galleryUI.setEnabledButTrash(false);
    }

    public void onClickButBack()
    {
        sceneController.OpenMainScene();
    }
    public void onClickButTrash()
    {
        Debug.Log(" нопка ButTrash была нажата");
    }
    public void onClickButPlay()
    {
        Debug.Log(" нопка ButPlay была нажата");
    }
    public void onClickButImport()
    {
        Debug.Log(" нопка ButImport была нажата");
    }
}
