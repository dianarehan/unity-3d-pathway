using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravityModifier;
    private bool isGrounded = true;
    public bool gameOver;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //float signal = Input.GetAxis("Jump");
        //Jump(signal);
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        
    }
    private void Jump(float signal)
    {
        if (signal>0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Log"))
        {
           gameOver = true;
        }
    }
}
