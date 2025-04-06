using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("current_level").ToString());
    }
}
