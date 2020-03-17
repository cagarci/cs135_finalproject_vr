﻿using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks;     // The time in seconds between each attack.
    public int attackDamage = 5;               // The amount of health taken away per attack.



    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    public bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    AudioSource enemyAudio;
    private SphereCollider col;
    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = gameObject.GetComponent<Animator>();
        col = GetComponent<SphereCollider>();
        timeBetweenAttacks = 3;
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
            
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
            anim.SetBool("InRange", playerInRange);
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange) //&& enemyHealth.currentHealth > 0)
        {
                // ... attack.
            Attack();
        }
        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
       {
            // ... tell the animator the player is dead.
            anim.SetBool("PlayerDead", true);
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0;
        anim.SetBool("InRange", playerInRange);
        enemyAudio.Play();
        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage();
        }
    }

}
