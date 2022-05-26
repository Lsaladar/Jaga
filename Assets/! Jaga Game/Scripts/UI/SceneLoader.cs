using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider progressBar;

    //public static GameManager instance;

    void Awake()
    {
        //instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndex.MainMenu, LoadSceneMode.Additive);
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadScene()
    {
        loadingScreen.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndex.MainMenu));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndex.MainScene, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while(!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;

                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count);

                progressBar.value = (totalSceneProgress);

                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }

    //public void LoadScene(int levelIndex)
    //{
    //    StartCoroutine(LoadAsychronously(levelIndex));
    //}

    //IEnumerator LoadAsychronously(int levelIndex)
    //{
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
    //    loadingScene.SetActive(true);
    //    while (!operation.isDone)
    //    {
    //        float progress = Mathf.Clamp01(operation.progress / 0.9f);
    //        //loadingBar.value = progress;

    //        yield return null;
    //    }
    //}
}
