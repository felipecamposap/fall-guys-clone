using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance of the object already exists, destroy this one to prevent duplicates.
            Destroy(gameObject);
        }
    }

    public void LoadScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
