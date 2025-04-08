using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorTrigger : MonoBehaviour
{
    [SerializeField] GameObject object_to_activate;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (object_to_activate != null)
            {
                object_to_activate.SetActive(true);
            }
        }
    }
}
