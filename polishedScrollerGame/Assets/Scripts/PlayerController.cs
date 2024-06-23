using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnim;
    private ParticleSystem explostionParticle;
    private ParticleSystem dirtParticle;
    private AudioSource audioSource;
    public AudioClip [] jumpSounds = new AudioClip[3];
    public AudioClip[] dieSounds = new AudioClip[3];
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravityModifier;
    private bool isGrounded = true;
    public bool gameOver;
   
    void Start()
    {
        explostionParticle = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
        dirtParticle=gameObject.transform.GetChild(1).GetComponent<ParticleSystem>();
        rb= GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            dirtParticle.Stop();
            dirtParticle.gameObject.SetActive(false);
            audioSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
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
            dirtParticle.gameObject.SetActive(true);
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Log"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",(int)Random.Range(1,3));
            explostionParticle.gameObject.SetActive(true);
            explostionParticle.Play();
            dirtParticle.Stop();
            dirtParticle.gameObject.SetActive(false);
            audioSource.PlayOneShot(dieSounds[Random.Range(0, dieSounds.Length)]);


        }
    }
}
