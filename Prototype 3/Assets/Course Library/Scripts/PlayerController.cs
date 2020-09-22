/*
 * Benjamin Schuster
 * Prototype 3
 * Control player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add onto player
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioSource musicRef;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);

        playerAudio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        if(Physics.gravity.y > -10)
            Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        if(collision.gameObject.CompareTag("obstacle"))
        {
            //set scene to game over
            gameOver = true;

            //control particles on death
            dirtParticle.Stop();
            explosionParticle.Play();

            //control audio on death
            musicRef.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            //control death animation
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
            
        }
    }
}
