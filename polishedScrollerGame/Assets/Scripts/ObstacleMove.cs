using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    float delay = 2f;
    float repeatRate = 2f;
    private PlayerController playerController;
    void Start()
    {   
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", delay, repeatRate);
    }

    void SpawnObstacle()
    {   
        if(!playerController.gameOver)
            Instantiate(obstacle, gameObject.transform);
        
    }

}
