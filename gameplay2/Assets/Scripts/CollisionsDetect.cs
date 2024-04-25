using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsDetect : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {   Destroy(gameObject);
        Destroy(other.gameObject);
        
    }
}
