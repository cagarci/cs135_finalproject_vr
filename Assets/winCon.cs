using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCon : MonoBehaviour
{
    GameObject player;
    PlayerItem playerItem;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerItem = player.GetComponent<PlayerItem>();
    }

    void OnTriggerStay(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            //if(keyNum >= 3)
            // ... the player is in range.
            //gameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
