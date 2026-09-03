using UnityEngine;
using UnityEngine.UI;

public class GalleryUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject butTrash;
    [SerializeField] private GameObject butPlay;
    [SerializeField] private GameObject butImport;
    [SerializeField] private GameObject butBack;

    public void setEnabledButTrash(bool enabled)
    {
        butTrash.GetComponent<Button>().enabled = enabled;
    }
    public void setEnabledButPlay(bool enabled)
    {
        butPlay.GetComponent<Button>().enabled = enabled;
    }
}
