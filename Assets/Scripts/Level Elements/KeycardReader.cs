using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardReader : MonoBehaviour
{
    [SerializeField] GameObject red_light;
    [SerializeField] GameObject green_light;
    [SerializeField] GameObject blue_light;
    [SerializeField] GameObject yellow_light;

    [SerializeField] ExitDoor door_to_open;

    public void readKeycards(List<Keycard.KeycardType> keycards)
    {
        Debug.Log("a");
        bool red = false;
        bool green = false;
        bool blue = false;
        bool yellow = false;

        if (keycards.Contains(Keycard.KeycardType.Red))
        {
            red_light.SetActive(true);
            red = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Green))
        {
            green_light.SetActive(true);
            green = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Blue))
        {
            blue_light.SetActive(true);
            blue = true;
        }

        if (keycards.Contains(Keycard.KeycardType.Yellow))
        {
            yellow_light.SetActive(true);
            yellow = true;
        }

        if (red && green && blue && yellow)
        {
            door_to_open.unlock();
        }
    }
}
