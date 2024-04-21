using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalX = Input.GetAxis("Horizontal1");
        float forBackZ = Input.GetAxis("Vertical1");
        transform.Translate(new Vector3(0, 0,forBackZ*Time.deltaTime* speed));
        transform.Rotate(new Vector3(0, horizontalX * Time.deltaTime * turnSpeed, 0));
     
    }
}
