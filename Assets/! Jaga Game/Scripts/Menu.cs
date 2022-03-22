using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Character Controller tests");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is now turned off");
    }
}
