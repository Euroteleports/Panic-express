using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }


    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.Escape))
        { 
            if (!isPaused)
            { 
                Debug.Log("Pause");
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                isPaused = true;
            }
            else
            {
                Debug.Log("Resume");
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                isPaused = false;
            }
        }
    }
}
