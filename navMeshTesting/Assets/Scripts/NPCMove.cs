using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCMove : MonoBehaviour
{
    [SerializeField] GameObject followed;
    NavMeshAgent agent;

    void Start(){

       agent = this.GetComponent<NavMeshAgent>();
        if (agent != null)
            SetDistantion();
    }

    private void SetDistantion() {
        if (followed != null)
        {
            agent.SetDestination(followed.GetComponent<Transform>().position);
        }
    }
}
