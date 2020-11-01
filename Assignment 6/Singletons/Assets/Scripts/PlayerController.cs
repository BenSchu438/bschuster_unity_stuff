/*
 * Benjamin Schuster
 * Assignment 6
 * Controls player movment (took from assignment 5, removed jumping)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    //Gravity
    public Vector3 velocity;
    public float gravity = -9.8f;
    public float gravityMulitplier = 2f;

    //checking ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public float jumpHeight = 3f;

    //win screen stuff
    //public GameObject WinScreen;
    //public bool gameOver = false;

    private void Awake()
    {
        gravity *= gravityMulitplier;
    }

    void Update()
    {       
        //check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //check input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

            //move player forward
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //let player jump
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}


            //add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
       

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Finish"))
    //    {
    //        WinScreen.SetActive(true);
    //        gameOver = true;
    //    }
    //}
}
