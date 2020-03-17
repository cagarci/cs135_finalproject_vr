using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySighting : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public bool PlayerInPresence;
    //public Vector3 personalLastSighting;

    public UnityEngine.AI.NavMeshAgent nav;
    private GameObject player;
    private GameObject enemy;
    private PlayerHealth playerHealth;
    public Animator anim;
    
    //private Vector3 previousSighting;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();

    }

    void update(){ 
    }
}