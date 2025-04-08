using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] Slider loading_bar;

    void Start()
    {
        StartCoroutine(loadLevelAsync());
        //SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("current_level").ToString());
    }

    IEnumerator loadLevelAsync()
    {
        AsyncOperation load_operation = SceneManager.LoadSceneAsync("SCN_Level" + PlayerPrefs.GetInt("current_level").ToString());

        while (!load_operation.isDone)
        {
            float progress_value = Mathf.Clamp01(load_operation.progress / 0.9f);
            loading_bar.value = progress_value;
            yield return null;
        }
    }
}
