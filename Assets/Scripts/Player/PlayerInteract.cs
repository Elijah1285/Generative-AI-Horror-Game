using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject player_camera;

    List<Keycard.KeycardType> collected_keycards = new List<Keycard.KeycardType>();

    [SerializeField] float max_interaction_distance;

    [SerializeField] LayerMask interactable_layer;

    [SerializeField] AudioSource main_audio_source;
    [SerializeField] AudioClip pickup_sound;

    void Start()
    {
        player_camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray ray = new Ray(player_camera.transform.position, player_camera.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, max_interaction_distance, interactable_layer))
            {
                if (hit.collider.tag == "Keycard")
                {
                    collected_keycards.Add(hit.collider.GetComponent<Keycard>().getKeycardType());
                    Destroy(hit.collider.gameObject);

                    main_audio_source.PlayOneShot(pickup_sound);
                }
                else if (hit.collider.tag == "KeycardReader")
                {
                    hit.collider.GetComponent<KeycardReader>().readKeycards(collected_keycards);
                }
            }
        }
    }
}
