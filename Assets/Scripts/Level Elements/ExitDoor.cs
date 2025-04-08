using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    bool locked = true;
    bool opening_door = false;
    float door_open_time_remaining = 2.0f;
    float try_open_timer = 0.0f;
    float try_open_cooldown = 0.5f;

    [SerializeField] int next_level; //the next level to load and save as the current, "0" takes player to the ending screen

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
                if (next_level == 0)
                {
                    SceneManager.LoadScene("Ending Screen");
                }
                else
                {
                    PlayerPrefs.SetInt("current_level", next_level);
                    SceneManager.LoadScene("SCN_LoadingScreen");
                }
            }
        }

        if (try_open_timer > 0.0f)
        {
            try_open_timer -= Time.deltaTime;
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
        if (!opening_door && try_open_timer <= 0)
        {
            if (!locked)
            {
                GetComponent<AudioSource>().PlayOneShot(door_open_sound);
                opening_door = true;

                //stop entity
                GameObject.FindWithTag("Entity").GetComponent<EntityAI>().disable();
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(door_open_fail_sound);
                try_open_timer = try_open_cooldown;
            }
        }
    }

    public bool getLocked()
    {
        return locked;
    }
}
