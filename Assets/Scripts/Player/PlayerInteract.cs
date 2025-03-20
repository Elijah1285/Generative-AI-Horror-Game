using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject camera;

    [SerializeField] float max_interaction_distance;

    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, max_interaction_distance))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
