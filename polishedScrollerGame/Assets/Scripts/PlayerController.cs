using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnim;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravityModifier;
    private bool isGrounded = true;
    public bool gameOver;
   
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity*=gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //float signal = Input.GetAxis("Jump");
        //Jump(signal);
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
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
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",(int)Random.Range(1,3));
            

            
        }
    }
}
