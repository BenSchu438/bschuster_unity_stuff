/*
 * Benjamin Schuster
 * Singletons
 * Golem, child of enemy class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    private bool attacking;
    private Animator animator;

    private AudioSource golemAudio;
    public AudioClip hurt;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        health = 150;
        damage = 35;
        speed = 5f;
        minDistance = 15f;
        attacking = false;

        animator = GetComponent<Animator>();
        golemAudio = GetComponent<AudioSource>();
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        Vector3 temp;
        while (true)
        {
            //look at player if not attacking
            if (!attacking)
            { 
                temp = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.LookAt(temp);
                animator.SetBool("Walk Forward", true);
            }

            //Move forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            //if its within range and not already attacking, use its attack 
            if (Vector3.Distance(player.transform.position, transform.position) <= minDistance && !attacking)
            {
                attacking = true;
                animator.SetBool("Walk Forward", false);
                StartCoroutine(Attack(damage));
            }

            yield return null;
        }

    }

    protected override IEnumerator Attack(int dmg)
    {
        speed = 0f;
        //stay still before attacking
        animator.SetBool("Smash Attack", true);
        yield return new WaitForSeconds(1.1f);

        //charge straight forward with increased speed
        animator.SetBool("Stab Attack", true);
        speed = 45f;
        
        yield return new WaitForSeconds(0.5f);

        //return speed to normal, stay still for a moment
        speed = 0f;
        yield return new WaitForSeconds(2f);

        speed = 5f;
        attacking = false;
    }

    //take damage, die
    public override void TakeDamage(int dmg)
    {
        health -= dmg;
        golemAudio.PlayOneShot(hurt);
        animator.SetBool("Take Damage", true);
        Debug.Log("Ouch! Dealt " + dmg + " damage! Rude!\n" + health + " health remaining.");
        if (health <= 0)
        {
            //If dead, call coroutine to let die (for animation purposes)
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(1.3f);

        GameManager.Instance.enemiesRemaining--;
        Destroy(gameObject);
    }

    //damage player on hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("touching player, should damage");
            player.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    
}
