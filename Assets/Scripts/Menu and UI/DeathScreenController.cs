using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene("Loading Screen");
    }

    public void returnToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
