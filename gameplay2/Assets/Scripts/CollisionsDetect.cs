using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsDetect : MonoBehaviour
{
    public GameObject player;
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerController.playerLive--;
            if(PlayerController.playerLive > 0 )
                Debug.Log("Live: "+ PlayerController.playerLive);
        }
        if (other.CompareTag("Pizza"))
        {
            PlayerController.playerScore++;
            Debug.Log("Score: " + PlayerController.playerScore);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }

}
