using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject player_camera;

    List<Keycard.KeycardType> collected_keycards = new List<Keycard.KeycardType>();

    [SerializeField] float max_interaction_distance;

    [SerializeField] GameObject red_keycard_2d;
    [SerializeField] GameObject green_keycard_2d;
    [SerializeField] GameObject blue_keycard_2d;
    [SerializeField] GameObject yellow_keycard_2d;

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
                    Keycard.KeycardType keycard_type = hit.collider.GetComponent<Keycard>().getKeycardType();

                    collected_keycards.Add(keycard_type);
                    Destroy(hit.collider.gameObject);

                    switch (keycard_type)
                    {
                        case (Keycard.KeycardType.Red):
                            {
                                red_keycard_2d.SetActive(true);

                                break;
                            }
                        case (Keycard.KeycardType.Green):
                            {
                                green_keycard_2d.SetActive(true);

                                break;
                            }
                        case (Keycard.KeycardType.Blue):
                            {
                                blue_keycard_2d.SetActive(true);

                                break;
                            }
                        case (Keycard.KeycardType.Yellow):
                            {
                                yellow_keycard_2d.SetActive(true);

                                break;
                            }
                    }

                    main_audio_source.PlayOneShot(pickup_sound);
                }
                else if (hit.collider.tag == "KeycardReader")
                {
                    hit.collider.GetComponent<KeycardReader>().readKeycards(collected_keycards);
                }
                else if (hit.collider.tag == "ExitDoor")
                {
                    hit.collider.GetComponent<ExitDoor>().tryOpen();
                }
            }
        } 
    }
}

