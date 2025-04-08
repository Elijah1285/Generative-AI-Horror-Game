using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void newGame()
    {
        PlayerPrefs.SetInt("current_level", 1);
        SceneManager.LoadScene("SCN_LoadingScreen");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("SCN_LoadingScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
