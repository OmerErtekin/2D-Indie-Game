using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoaderScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void loadLevel (int sceneIndex)
    {
        StartCoroutine(loadAsynchronously(sceneIndex));
    }

    IEnumerator loadAsynchronously(int sceneIndex)
    {
        float time = 0;
        if(PlayerPrefs.GetInt("playCount") != 4)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            loadingScreen.SetActive(true);
            while (SceneManager.GetActiveScene().buildIndex != 1)
            {
                time += Time.deltaTime;
                //Debug.Log(time);
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                if (slider.maxValue > time * 4)
                {
                    slider.value = time * 4;
                }
                yield return null;
            }
        }
    }
}
