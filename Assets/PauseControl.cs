using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool menuOpen = false;


    // Update is called once per frame
    void Update()
    {
       if (!menuOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuOpen = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;

            }

            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    menuOpen = false;
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1.0f;

                }
            }
        }

    }

    public void ContGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f; 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

