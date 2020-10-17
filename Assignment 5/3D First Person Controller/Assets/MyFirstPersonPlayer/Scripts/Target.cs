/*
 * Benjamin Schuster
 * Assignment 5
 * Health system for targets
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public DoorScript linkedDoor;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //tell whatever door its linked with that its been destroyed
        if (linkedDoor != null)
            linkedDoor.TargetDestroyed();
        Destroy(gameObject);
    }
}
