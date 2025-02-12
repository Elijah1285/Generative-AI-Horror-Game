using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EntityChase : MonoBehaviour
{
    Transform player;

    NavMeshAgent nav_mesh_agent;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
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
