using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInPresence : MonoBehaviour
{
    private EnemySighting enemy;
    private SphereCollider sph;
    private GameObject player;
    void Start()
    {
        enemy = GetComponentInParent<EnemySighting>();
        sph = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            enemy.PlayerInPresence = true;
            Debug.Log("PlayerInPresent = " + enemy.PlayerInPresence);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            enemy.PlayerInPresence = false;
            Debug.Log("PlayerInPresent = " + enemy.PlayerInPresence);
        }
    }
    void Update()
    {
        
    }
}
