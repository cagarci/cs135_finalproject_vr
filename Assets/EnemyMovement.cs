using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float patrolSpeed = 1f;
    public float chaseSpeed = 2f;
    public float patrolWaitTime = 1f;
    public float chaseWaitTime = 5f;
    public Transform[] patrolWayPoints;

    private Transform player;               // Reference to the player's position.
    private PlayerHealth playerHealth;      // Reference to the player's health.
    private EnemySighting enemySighting;
    private EnemyAttack PlayerInRange;
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    private UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

    private float patrolTimer;
    private float chaseTimer;
    private int wayPointIndex;

    Animator anim;
    private bool playerFound;
    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemySighting = GetComponent<EnemySighting>();
        PlayerInRange = GetComponent<EnemyAttack>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerFound = false;
    }


    void Update()
    {
        if (playerFound == false)
        {
            anim.SetBool("Patrolling", true);
            Patrolling();
        }
        // If the enemy and the player have health left...
        if (PlayerInRange.playerInRange && playerHealth.currentHealth > 0)
        {
            Attacking();
        }
        else if ((playerHealth.currentHealth > 0 && enemySighting.PlayerInPresence && enemySighting.playerInSight) || (playerFound  ))
        {
            // ... set the destination of the nav mesh agent to the player.
            playerFound = true;
            anim.SetBool("Patrolling", false);
            anim.SetBool("Chasing", true);
            Chasing();
        }
        // Otherwise...


        
    }
   
    void Chasing()
    {
        
        nav.enabled = true;
        nav.speed = chaseSpeed;
        nav.SetDestination(player.position);
    }

    void Patrolling()
    {
        
        nav.speed = patrolSpeed;
        if(/*nav.destination != player.position ||*/ nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            if(patrolTimer >= patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;
                patrolTimer = 0f;
            }
        }
        else
            patrolTimer = 0f;
        nav.destination = patrolWayPoints[wayPointIndex].position;
    }

    void Attacking()
    {
        anim.SetBool("Chasing", false);
    }
}