using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    Resolution[] resolutions;
    [Tooltip("Creates a list for the resolution used in the dropdown menu")] public TMPro.TMP_Dropdown resolutionDropdown;

    public GameObject audioSource;

    public AudioMixer mixer;

    public void StartGame()
    {
        SceneManager.LoadScene("Character Controller tests");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is now turned off");
    }

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetLevel(float slider)
    {
        mixer.SetFloat("MusicVolumeMixer", Mathf.Log10(slider) * 20);
    }

    public void OnBeingDrag()
    {
        audioSource.SetActive(true);
        Debug.Log("You are dragging the slider");
    }

    public void OnEndDrag()
    {
        audioSource.SetActive(false);
        Debug.Log("You are no longer dragging the slider");
    }
}
