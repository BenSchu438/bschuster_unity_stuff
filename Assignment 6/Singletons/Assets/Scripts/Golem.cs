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

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 150;
        damage = 100;
        speed = 5f;
        minDistance = 15f;
        attacking = false;
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
            }

            //Move forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            //if its within range and not already attacking, use its attack 
            if (Vector3.Distance(player.transform.position, transform.position) <= minDistance && !attacking)
            {
                attacking = true;
                StartCoroutine(Attack(damage));
            }

            yield return null;
        }

    }

    protected override IEnumerator Attack(int dmg)
    {
        speed = 0f;
        //stay still before attacking
        yield return new WaitForSeconds(2f);

        //charge straight forward with increased speed
        speed = 45f;
        
        yield return new WaitForSeconds(0.5f);

        //return speed to normal, stay still for a moment
        speed = 0f;
        yield return new WaitForSeconds(3f);

        speed = 5f;
        attacking = false;
    }

    public override void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Ouch! Dealt " + dmg + " damage! Rude!\n" + health + " health remaining.");
        if (health <= 0)
        {
            //If dead, deincrement win condition and destroy
            GameManager.Instance.enemiesRemaining--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("touching player, should damage");
            player.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    
}
