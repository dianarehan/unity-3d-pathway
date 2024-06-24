using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerY : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody rb;
    private float zBound = 37f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.forward * vertical * speed);
        rb.AddForce(Vector3.right * horizontal * speed);
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,-zBound);
        }
        else if(transform.position.z > zBound) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
}
