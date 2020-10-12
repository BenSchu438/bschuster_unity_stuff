/*
 * Benjamin Schuster
 * Prototype 4
 * Controls player and resets if falls 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 startPosition;
    private Score gameRef;

    // Use this for initialization
    void Awake () 
    {
        gameRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
        startPosition = new Vector2(transform.position.x, transform.position.y);
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (!gameRef.gameOver)
        {
            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && grounded) {
                velocity.y = jumpTakeOffSpeed;
            } else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0) {
                    velocity.y = velocity.y * 0.5f;
                }
            }
    }

        if(move.x > 0.01f)
        {
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        else if (move.x < -0.01f)
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        //set player back at start if falls off
        if(transform.position.y <= -5)
        {
            transform.position = startPosition;
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
        animator.SetFloat("velocityY", velocity.y);
        targetVelocity = move * maxSpeed;
    }
}