using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    public GameObject loadingScreen;
    public Slider progressBar;

    void Awake()
    {
        Instance = this;

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
}
