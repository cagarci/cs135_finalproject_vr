using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(playerItem.keyNum >= 3)
                gameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void gameOver()
    {
        Invoke("RestartScene", 4.0f);
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
