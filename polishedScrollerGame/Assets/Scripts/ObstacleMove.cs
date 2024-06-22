using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    float delay = 3f;
    float repeatRate = 2f;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", delay, repeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, gameObject.transform);
        
    }

}
