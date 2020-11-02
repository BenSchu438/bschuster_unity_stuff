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
    //additional variables for variet
    private bool attacking;
    private float minDistance;

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
        enemyAudio = GetComponent<AudioSource>();
        StartCoroutine(Move());
    }

    //specialized movement
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
                StartCoroutine(Attack());
            }

            yield return null;
        }

    }

    //specialized attack
    protected override IEnumerator Attack()
    {
        speed = 0f;
        enemyAudio.PlayOneShot(roar);
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
}
