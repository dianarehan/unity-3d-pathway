using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed=15;
    private float rotationSpeed=60;
    public GameObject propeller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        float verticalInput = -Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed* horizontalInput* Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime * verticalInput, 0,0));
        this.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, 25));
    }
}
