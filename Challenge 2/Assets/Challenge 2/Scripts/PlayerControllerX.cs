/*
 * Benjamin Schuster
 * Challenge 2
 * Spawns dog from player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogDelay = 1.0f;
    private float nextDog;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        // Has about a 1 second cooldown
        if(Time.time > nextDog)
        {
            if (Input.GetKeyDown(KeyCode.Space))
             {
               Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                nextDog = Time.time + dogDelay;
            
            }
        }
        
    }
}
