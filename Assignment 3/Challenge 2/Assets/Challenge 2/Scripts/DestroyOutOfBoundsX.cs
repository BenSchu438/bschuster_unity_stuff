/*
 * Benjamin Schuster
 * Challenge 2
 * Destroys objects that go off-screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -36;
    private float bottomLimit = -1;

    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("healthCore").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            healthSystem.TakeDamage();
            Destroy(gameObject);
        }

    }
}
