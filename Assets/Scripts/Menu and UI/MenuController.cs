using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void newGame()
    {
        PlayerPrefs.SetInt("current_level", 1);
        SceneManager.LoadScene("Loading Screen");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Loading Screen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
