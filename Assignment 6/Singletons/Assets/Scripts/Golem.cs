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
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 150;
        damage = 30;
        speed = 5f;
        minDistance = 7f;
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        Vector3 temp;
        //move towards player, or stop if too close
        while(true)
        {
            temp = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(temp);

            if(Vector3.Distance(player.transform.position, transform.position) >= minDistance)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return null;
        }

    }

    protected override void Attack(int dmg)
    {
        Debug.Log("Golem Attack");
    }

    public override void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Ouch! Dealt " + dmg + " damage! Rude!\n" + health + " health remaining.");
        if (health <= 0)
            Destroy(gameObject);
    }
}
