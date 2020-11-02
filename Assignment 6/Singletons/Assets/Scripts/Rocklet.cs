/*
 * Benjamin Schuster
 * Singletons
 * Golem, child of enemy class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocklet : Enemy
{
    private bool attacking;
    private Animator animator;

    private AudioSource golemAudio;
    public AudioClip roar;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        health = 40;
        damage = 10;
        speed = 9f;
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
            //if (Vector3.Distance(player.transform.position, transform.position) <= minDistance && !attacking)
            //{
            //    attacking = true;
            //    animator.SetBool("Walk Forward", false);
            //    StartCoroutine(Attack());
            //}

            yield return null;
        }

    }

    protected override IEnumerator Attack()
    {
        //stay still for a second after attacking
        speed = 0f;
        golemAudio.PlayOneShot(roar);
        animator.SetBool("Stab Attack", true);
        yield return new WaitForSeconds(1f);

        //resume normal follow
        animator.SetBool("Stab Attack", true);
        speed = 9f;
    }

    //take damage, die
    public override void TakeDamage(int dmg)
    {
        health -= dmg;
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
        speed = 0f;
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(1f);

        GameManager.Instance.enemiesRemaining--;
        Destroy(gameObject);
    }

    //damage player on hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            StartCoroutine(Attack());
            player.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    
}
