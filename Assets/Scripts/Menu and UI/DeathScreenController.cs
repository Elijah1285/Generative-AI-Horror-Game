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
        SceneManager.LoadScene("Loading Screen");
    }

    public void returnToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
