using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float patrolSpeed = 0.5f;
    public float chaseSpeed = 1f;
    public float patrolWaitTime = 1f;
    public float chaseWaitTime = 5f;

    private Transform player;               // Reference to the player's position.
    private PlayerHealth playerHealth;      // Reference to the player's health.
    private EnemySighting enemySighting;
    private EnemySighting playerInPresence;
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    private UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    private float patrolTimer;
    private float chaseTimer;
    private int wayPointIndex;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemySighting = GetComponent<EnemySighting>();
        playerInPresence = GetComponent<EnemySighting>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (playerHealth.currentHealth > 0 && playerInPresence == true)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
               nav.enabled = false;
        }
    }

    void Chasing()
    {

    }

    void Patrolling()
    {

    }
}