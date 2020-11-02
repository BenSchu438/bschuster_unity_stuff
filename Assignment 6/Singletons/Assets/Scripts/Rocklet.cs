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

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        health = 40;
        damage = 10;
        speed = 11f;

        animator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        StartCoroutine(Move());
    }

    //specialized move method
    protected override IEnumerator Move()
    {
        Vector3 temp;
        while (true)
        {
            //chase player 
            temp = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(temp);
            animator.SetBool("Walk Forward", true);

            //Move forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return null;
        }

    }

    //specialized attack method
    protected override IEnumerator Attack()
    {
        //stay still for a second after attacking
        speed = 0f;
        enemyAudio.PlayOneShot(roar);
        animator.SetBool("Stab Attack", true);
        yield return new WaitForSeconds(1f);

        //resume normal follow
        animator.SetBool("Stab Attack", true);
        speed = 9f;
    }
}
