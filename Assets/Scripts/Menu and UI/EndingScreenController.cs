using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreenController : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void returnToTitleScreen()
    {
        SceneManager.LoadScene("SCN_TitleScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
