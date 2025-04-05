using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    bool locked = true;
    bool opening_door = false;
    float door_open_time_remaining = 2.0f;

    [SerializeField] string next_scene_name;

    [SerializeField] GameObject door_light;
    [SerializeField] Material green_door_light_material;
    [SerializeField] AudioClip door_open_sound;
    [SerializeField] AudioClip door_open_fail_sound;

    void Update()
    {
        if (opening_door)
        {
            door_open_time_remaining -= Time.deltaTime;

            if (door_open_time_remaining <= 0.0f)
            {
                SceneManager.LoadScene(next_scene_name);
            }
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

    public void tryOpen()
    {
        if (!locked)
        {
            GetComponent<AudioSource>().PlayOneShot(door_open_sound);
            opening_door = true;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(door_open_fail_sound);
        }
    }

    public bool getLocked()
    {
        return locked;
    }
}
