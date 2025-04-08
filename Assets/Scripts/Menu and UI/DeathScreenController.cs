using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void retry()
    {
        SceneManager.LoadScene("SCN_LoadingScreen");
    }

    public void returnToTitleScreen()
    {
        SceneManager.LoadScene("SCN_TitleScreen");
    }
}
