using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreenController : MonoBehaviour
{
    public void returnToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
