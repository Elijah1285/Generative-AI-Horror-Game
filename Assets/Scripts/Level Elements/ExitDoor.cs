using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    bool locked = true;

    void OnTriggerEnter(Collider other)
    {
        if (!locked && other.tag == "Player")
        {
            SceneManager.LoadScene("Ending");
        }
    }

    public void unlock()
    {
        locked = false;
    }
}
