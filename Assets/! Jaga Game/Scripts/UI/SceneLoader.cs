using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider loadingBar;

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadAsychronously(levelIndex));
    }

    IEnumerator LoadAsychronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;

            yield return null;
        }
    }
}
