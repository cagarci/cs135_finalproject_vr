using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayInPresence : MonoBehaviour
{
    private EnemySighting enemy;
    
    private SphereCollider sph;
    private GameObject player;
    private float angle;
    private Animator weaponHolderAnimator;

    void Start()
    {
        enemy = GetComponentInParent<EnemySighting>();
        sph = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        angle = enemy.fieldOfViewAngle;
        weaponHolderAnimator = GameObject.Find("Weapon holder").GetComponent<Animator>();
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            enemy.PlayerInPresence = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            enemy.PlayerInPresence = false;
            enemy.anim.SetBool("InPresence", false);
        }
    }
    void Update()
    {
        if (enemy.PlayerInPresence)
        {
            enemy.anim.SetBool("InPresence", true);
            enemy.playerInSight = false;
            Vector3 direction = player.transform.position - transform.position;
            float angle1 = Vector3.Angle(direction, transform.forward);
            RaycastHit hit;
            Ray eyesight = new Ray(transform.position, Vector3.forward);
            Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
            if (angle1 < angle * 0.5)
            {

                if (Physics.Raycast(eyesight, out hit, 5))
                {
                    //Debug.DrawRay(transform.position + transform.up, transform.forward, Color.green); print("Hit");
                    if (hit.collider.tag == "Player")
                    {

                        enemy.playerInSight = true;
                        enemy.anim.SetBool("InSight", true);
                        
                    }
          
                }

                if (weaponHolderAnimator.GetBool("Run"))
                {
                    if(CalculatePathLength(player.transform.position) <= 5)
                    {
                        enemy.playerInSight = true;
                        enemy.anim.SetBool("InSight", true);
                    }
                }
            }
        }
        else
        {
            enemy.playerInSight = false;
            enemy.anim.SetBool("InSight", false);
        }
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();

        if (enemy.nav.enabled)
            enemy.nav.CalculatePath(targetPosition, path);
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0f;
        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
        return pathLength;
    }
}
