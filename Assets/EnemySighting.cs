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

    private UnityEngine.AI.NavMeshAgent nav;
    private GameObject player;
    private GameObject enemy;
    private PlayerHealth playerHealth;
    //private Vector3 previousSighting;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void update(){ 
        if (PlayerInPresence)
        {
            playerInSight = false;
            Vector3 direction = player.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if (angle < fieldOfViewAngle * 0.5)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, 3))
                {
                    Debug.DrawRay(transform.position + transform.up, transform.forward, Color.green); print("Hit");
                    if (hit.collider.gameObject == player)
                    {
                        
                        playerInSight = true;
                    }
                }

            }
        }
        else
        {
            playerInSight = false;
        }
    }
}