using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    bool locked = true;

    [SerializeField] GameObject door_light;

    [SerializeField] Material green_door_light_material;

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

        for (int i = 0; i < door_light.transform.childCount; i++)
        {
            door_light.transform.GetChild(i).GetComponent<Renderer>().material = green_door_light_material;
        }
    }
}
