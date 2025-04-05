using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardReader : MonoBehaviour
{
    [SerializeField] float time_to_unlock_door;

    [SerializeField] GameObject red_light;
    [SerializeField] GameObject green_light;
    [SerializeField] GameObject blue_light;
    [SerializeField] GameObject yellow_light;

    [SerializeField] ExitDoor door_to_open;

    [SerializeField] AudioClip scan_sound;
    [SerializeField] AudioClip access_granted_sound;

    AudioSource audio_source;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void readKeycards(List<Keycard.KeycardType> keycards)
    {
        bool red = false;
        bool green = false;
        bool blue = false;
        bool yellow = false;

        bool playing_scan_sound = false;

        if (keycards.Contains(Keycard.KeycardType.Red))
        {
            if (!red_light.activeSelf)
            {
                tryPlayScanSound(playing_scan_sound);
                playing_scan_sound = true;
            }

            red_light.SetActive(true);
            red = true;        
        }

        if (keycards.Contains(Keycard.KeycardType.Green))
        {
            if (!green_light.activeSelf)
            {
                tryPlayScanSound(playing_scan_sound);
                playing_scan_sound = true;
            }

            green_light.SetActive(true);
            green = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Blue))
        {
            if (!blue_light.activeSelf)
            {
                tryPlayScanSound(playing_scan_sound);
                playing_scan_sound = true;
            }

            blue_light.SetActive(true);
            blue = true;            
        }

        if (keycards.Contains(Keycard.KeycardType.Yellow))
        {
            if (!yellow_light.activeSelf)
            {
                tryPlayScanSound(playing_scan_sound);
                playing_scan_sound = true;
            }

            yellow_light.SetActive(true);
            yellow = true;            
        }

        if (red && green && blue && yellow)
        {
            startDoorUnlock();
        }
    }

    void tryPlayScanSound(bool playing_scan_sound)
    {
        if (!playing_scan_sound)
        {
            audio_source.PlayOneShot(scan_sound);
        }
    }

    void startDoorUnlock()
    {
        Debug.Log("a");
        StartCoroutine(timeBeforeDoorUnlock());
    }

    IEnumerator timeBeforeDoorUnlock()
    {
        yield return new WaitForSeconds(time_to_unlock_door);

        unlockDoor();
        Debug.Log("unlocked");
    }

    void unlockDoor()
    {
        door_to_open.unlock();

        audio_source.PlayOneShot(access_granted_sound);
    }
}
