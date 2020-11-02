/*
 * Benjamin Schuster
 * Assignment 6
 * Controls player (took from assignment 5, removed jumping, heavily modified)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageable
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

    //weapon stuff
    [SerializeField]
    private Weapon weapon;

    //gamestate stuff
    private int health = 100;
    private bool vulnerable = true;
    public Slider slider;

    //sound effects
    private AudioSource playerAudio;
    public AudioClip hurt;


    private void Awake()
    {
        gravity *= gravityMulitplier;
        weapon = GetComponentInChildren<Sword>();
        slider = GameObject.FindGameObjectWithTag("UI").GetComponentInChildren<Slider>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {       
        //check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

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

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Attack();
        }
    }

    //methods about player health
    public void TakeDamage(int dmg)
    {
        
        if (vulnerable)
        {
            health -= dmg;
            slider.value = health;
            playerAudio.PlayOneShot(hurt);
            Debug.Log("Player took damage, " + health + " health remaining.");
            vulnerable = false;
            StartCoroutine(Invulnerable());
        }
        if (health <= 0)
            GameManager.Instance.gameOver = true;
    }
    //make it so player has 3 seconds invulnerability after being hit
    private protected IEnumerator Invulnerable()
    {
        Debug.Log("Invulnerable");
        yield return new WaitForSeconds(1f);
        vulnerable = true;
        Debug.Log("Vulnerable");
    }
}
