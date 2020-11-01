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
    }
    protected override void Attack(int dmg)
    {
        Debug.Log("Golem Attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Ouch! Dealt " + dmg + " damage! Rude!\n" + health + " health remaining.");
        if (health <= 0)
            Destroy(gameObject);
    }
}
