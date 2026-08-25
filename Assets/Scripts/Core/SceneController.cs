using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void OpenMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void OpenGallery()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gallery");
    }
    public void OpenViewer()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Viewer");
    }

}
