using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
