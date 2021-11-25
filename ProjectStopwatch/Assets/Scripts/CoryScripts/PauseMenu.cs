using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string _newGameLevel;
    public static bool Paused = false;
    public GameObject PauseMenuUI;
    public GameObject DeathScreenUI;
    public GameObject WinScreen;

    void Update()
    {
        if (DeathScreenUI.activeInHierarchy == false && WinScreen.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Paused)
                {
                    Resume();


                }
                else
                {
                    Pause();

                }
            }
        }
        if (WinScreen.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
        }
       
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(_newGameLevel);
        Paused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        Paused = false;
    }

    public void QuitGame()
    {
        Debug.Log("LL");
        Application.Quit();
    }
}
