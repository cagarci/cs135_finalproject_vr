using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getKey1 : MonoBehaviour
{
    //public MeshRenderer k;
    GameObject player;
    GameObject key1;
    PlayerItem playerItem;
    GameObject sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerItem = player.GetComponent<PlayerItem>();
        key1 = GameObject.FindGameObjectWithTag("Key");
        //k = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            if (Input.GetKey("a"))
            {
                playerItem.keyNum += 1;
                //k.enabled = false;
                Destroy(key1);
            }
        }
    }
    void Update()
    {
          
    }
    
}
