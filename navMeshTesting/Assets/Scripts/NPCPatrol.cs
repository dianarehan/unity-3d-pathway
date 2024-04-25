using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    [SerializeField] bool patWaits;
    [SerializeField] float totalWaitTime = 3;
    [SerializeField] float switchProbability = 0.2f;
    [SerializeField] List<PointShape> points;
    NavMeshAgent navMeshAgent;

    int currPatIndex;
    bool travelling;
    bool waiting;
    bool patrolFowrad;
    float waitTimer;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        currPatIndex = 0;
        SetDestination();
    }

    private void SetDestination()
    {
        if (points != null)
        {
            Vector3 destination = points[currPatIndex].transform.position;
            navMeshAgent.SetDestination(destination);
            travelling = true;
        }
    }
    void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0, 1f) <= switchProbability) 
        
            patrolFowrad=!patrolFowrad;
        
        if(patrolFowrad)//move forward in the array points
        
           currPatIndex=(currPatIndex+1)%points.Count;
        
        else if(--currPatIndex<0)  //chose to move backwards dfrom the array points depending on the prob value
            currPatIndex=points.Count-1;
    }
    void Update()
    {
        if(travelling && navMeshAgent.remainingDistance<=0.1f)
        {
            travelling=false;
            if (patWaits)//wait upon checking the global flag patwaits
            {
                waitTimer =0f;
                waiting = true;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }
        if (waiting) //if he should waits start counting to the total wait time if it exceeded chnage your point and go
        {
            waitTimer += Time.deltaTime;
            if(waitTimer>=totalWaitTime)
            {

                waiting = false;
                ChangePatrolPoint();
                SetDestination();
            }
        }
    }
}
