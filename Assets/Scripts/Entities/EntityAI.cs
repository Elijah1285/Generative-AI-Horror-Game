using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EntityAI : MonoBehaviour
{
    bool jumpscaring = false;
    bool disabled = false;

    Transform player;

    AudioSource audio_source;

    NavMeshAgent nav_mesh_agent;

    [SerializeField] GameObject jumpscare;

    [SerializeField] AudioClip jumpscare_sound;

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
                SceneManager.LoadScene("SCN_DeathScreen");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !jumpscaring && !disabled)
        {
            jumpscaring = true;
            jumpscare.SetActive(true);

            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(jumpscare_sound);
        }
    }

    public void disable()
    {
        disabled = true;
        nav_mesh_agent.speed = 0.0f;
    }
}
