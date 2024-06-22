using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 10f;
    
    void Update()
    {
        gameObject.transform.Translate(Vector3.left* speed * Time.deltaTime);
        if (gameObject.transform.position.x < -25|| gameObject.transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
