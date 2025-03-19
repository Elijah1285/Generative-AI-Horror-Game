using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    bool played_sound = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!played_sound)
            {

            }
        }
    }
}
