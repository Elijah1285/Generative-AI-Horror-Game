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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
