/*
 * Benjamin Schuster
 * Challenge 3
 * Player controller
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private bool isLowEnough = true;
    public float upperBound;

    public float floatForce;
    public float bounceForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ForceMode floatForceMode;
    public ForceMode bounceForceMode;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

    private ScoreManagerX scoreRef;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        scoreRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManagerX>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < upperBound)
            isLowEnough = true;
        else
            isLowEnough = false;

        // While space is pressed and player is low enough, float up (ask professor)
        if (Input.GetKey(KeyCode.Space) && !scoreRef.gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce, floatForceMode);
        }

        //prevent inertia from flinging balloon offscreen
        if (!isLowEnough)
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            scoreRef.gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            scoreRef.score++;
            Destroy(other.gameObject);
        }

        // if player collides with ground, bounce
        else if (other.gameObject.CompareTag("Ground") && !scoreRef.gameOver)
        {
            playerRb.AddForce(Vector3.up * bounceForce, bounceForceMode);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
