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

        if (keycards.Contains(Keycard.KeycardType.Red) && !red_light.activeSelf)
        {
            red_light.SetActive(true);
            red = true;

            tryPlayScanSound(playing_scan_sound);
            playing_scan_sound = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Green) && !green_light.activeSelf)
        {
            green_light.SetActive(true);
            green = true;

            tryPlayScanSound(playing_scan_sound);
            playing_scan_sound = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Blue) && !blue_light.activeSelf)
        {
            blue_light.SetActive(true);
            blue = true;

            tryPlayScanSound(playing_scan_sound);
            playing_scan_sound = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Yellow) && !yellow_light.activeSelf)
        {
            yellow_light.SetActive(true);
            yellow = true;

            tryPlayScanSound(playing_scan_sound);
            playing_scan_sound = true;
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
