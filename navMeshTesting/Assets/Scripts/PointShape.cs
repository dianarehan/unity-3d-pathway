using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShape : MonoBehaviour
{
    float radius = 1;


     void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, radius);  
    }
}
