using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EntityAI : MonoBehaviour
{
    Transform player;

    AudioSource audio_source;

    NavMeshAgent nav_mesh_agent;

    [SerializeField] GameObject jumpscare;

    [SerializeField] AudioClip jumpscare_sound;

    enum EntityState
    {

    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        audio_source = GetComponent<AudioSource>();
        nav_mesh_agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav_mesh_agent.destination = player.position;

        if (jumpscare.activeSelf)
        {
            if (jumpscare.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                SceneManager.LoadScene("Death Screen");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jumpscare.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(jumpscare_sound);
        }
    }
}
